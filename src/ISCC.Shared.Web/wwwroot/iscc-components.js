/*
 * Shared component behaviour for every portal.
 *
 * Replaces the inline jQuery blocks the legacy ImportingProcedure and ExportingProcedure
 * views carried. Those were ~60 near-identical lines per page: initialise select2, then
 * for a cascading dropdown disable, fetch, repopulate, re-enable, trigger change.
 *
 * Here that is declared once and driven by data attributes emitted by Select2TagHelper:
 *   data-iscc-select2            marks a control to enhance
 *   data-placeholder             placeholder text
 *   data-allow-clear             enables the clear button
 *   data-minimum-search-length   keystrokes before an AJAX search fires
 *   data-ajax-url                endpoint returning options
 *   data-ajax-param              query parameter carrying the parent value
 *   data-depends-on              id of the parent control to cascade from
 */
(function () {
    'use strict';

    var LOADING = '__iscc_loading__';

    function buildOptions(payload) {
        // Accepts either a bare array or the { items: [...] } / { data: [...] } envelope,
        // so an endpoint can return an ApiResponse and a plain list both work.
        var list = payload;
        if (payload && !Array.isArray(payload)) {
            list = payload.items || payload.data || payload.results || [];
        }
        if (!Array.isArray(list)) { return []; }

        return list.map(function (item) {
            if (typeof item === 'string') { return { id: item, text: item }; }
            var id = item.id !== undefined ? item.id : item.value;
            var text = item.text !== undefined ? item.text
                : (item.name !== undefined ? item.name : id);
            return { id: id, text: text, disabled: !!item.disabled };
        });
    }

    function fetchOptions(url, params) {
        var query = Object.keys(params || {})
            .filter(function (k) { return params[k] !== undefined && params[k] !== null && params[k] !== ''; })
            .map(function (k) { return encodeURIComponent(k) + '=' + encodeURIComponent(params[k]); })
            .join('&');

        var full = query ? url + (url.indexOf('?') === -1 ? '?' : '&') + query : url;

        return fetch(full, { headers: { 'X-Requested-With': 'XMLHttpRequest' } })
            .then(function (response) {
                if (!response.ok) { throw new Error('Request failed with status ' + response.status); }
                return response.json();
            })
            .then(buildOptions);
    }

    function select2Options($el) {
        var opts = {
            width: '100%',
            allowClear: $el.data('allow-clear') === true || $el.data('allow-clear') === 'true',
            placeholder: $el.data('placeholder') || ''
        };

        var min = parseInt($el.data('minimum-search-length'), 10);
        if (!isNaN(min) && min > 0) { opts.minimumResultsForSearch = min; }

        var ajaxUrl = $el.data('ajax-url');
        if (ajaxUrl) {
            opts.ajax = {
                url: ajaxUrl,
                dataType: 'json',
                delay: 300,
                data: function (params) {
                    var payload = { term: params.term || '', page: params.page || 1 };
                    var param = $el.data('ajax-param');
                    if (param) {
                        var dependsOn = $el.data('depends-on');
                        if (dependsOn && $('#' + dependsOn).length) {
                            payload[param] = $('#' + dependsOn).val();
                        }
                    }
                    return payload;
                },
                processResults: function (payload) {
                    return { results: buildOptions(payload) };
                }
            };
        }

        return opts;
    }

    function enhance(el) {
        var $el = $(el);
        if (!$el.data('iscc-initialised')) {
            $el.select2(select2Options($el));
            $el.data('iscc-initialised', true);
        }

        // Cascade: reload this control's options when the parent changes.
        var dependsOn = $el.data('depends-on');
        var ajaxUrl = $el.data('ajax-url');
        var ajaxParam = $el.data('ajax-param');

        if (!dependsOn || !ajaxUrl || !ajaxParam) { return; }

        var $parent = $('#' + dependsOn);
        if (!$parent.length || $parent.data('iscc-cascade-bound')) { return; }

        $parent.on('change', function () {
            var value = $(this).val();

            if (!value || value === '0' || value === LOADING) {
                // No parent chosen: clear and re-enable rather than leaving a stale list.
                $el.empty();
                if ($el.data('placeholder')) {
                    $el.append($('<option></option>').val('').text($el.data('placeholder')));
                }
                $el.trigger('change.select2');
                $el.prop('disabled', false);
                return;
            }

            $el.prop('disabled', true);
            $el.empty();
            $el.append($('<option></option>').val('').text(LOADING));
            $el.trigger('change.select2');

            var payload = {};
            payload[ajaxParam] = value;

            fetchOptions(ajaxUrl, payload)
                .then(function (options) {
                    $el.empty();
                    options.forEach(function (option) {
                        $el.append($('<option></option>')
                            .val(option.id)
                            .text(option.text)
                            .prop('disabled', !!option.disabled));
                    });
                })
                .catch(function (error) {
                    console.error('Failed to load options for', $el.attr('id'), error);
                    $el.empty();
                })
                .finally(function () {
                    $el.prop('disabled', false);
                    $el.trigger('change.select2');
                });
        });

        $parent.data('iscc-cascade-bound', true);
    }

    function init() {
        if (typeof $ === 'undefined') {
            console.warn('ISCC components: jQuery is required. Add <iscc-scripts jquery="true" />.');
            return;
        }
        if (typeof $.fn.select2 === 'undefined') {
            console.warn('ISCC components: select2 is not loaded. Searchable selects will be inert.');
            return;
        }

        $('[data-iscc-select2]').each(function () { enhance(this); });
    }

    // Run on ready and again after any partial update.
    $(init);
    $(document).on('ajaxComplete', init);

    // Expose for tests and for pages that build markup dynamically.
    window.ISCC = window.ISCC || {};
    window.ISCC.initComponents = init;
    window.ISCC.enhanceSelect2 = enhance;
})();
