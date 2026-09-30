(function ($) {
    "use strict";
    
    // Leave time to move from the navbar heading into its dropdown items.
    $(document).ready(function () {
        var hoverNavigation = window.matchMedia('(min-width: 992px) and (hover: hover) and (pointer: fine)');

        $('.navbar .dropdown').each(function () {
            var dropdown = this;
            var toggle = dropdown.querySelector('.dropdown-toggle');
            var closeTimer;
            if (!toggle) return;

            function cancelClose() {
                window.clearTimeout(closeTimer);
            }

            $(dropdown).on('mouseenter.navbarHover', function () {
                cancelClose();
                if (hoverNavigation.matches) {
                    bootstrap.Dropdown.getOrCreateInstance(toggle).show();
                }
            }).on('mouseleave.navbarHover', function () {
                if (!hoverNavigation.matches) return;
                cancelClose();
                closeTimer = window.setTimeout(function () {
                    // Keyboard users may still be choosing an item inside the menu.
                    if (!dropdown.querySelector('.dropdown-menu').contains(document.activeElement)) {
                        bootstrap.Dropdown.getOrCreateInstance(toggle).hide();
                    }
                }, 350);
            }).on('focusin.navbarHover', cancelClose);

            toggle.addEventListener('hide.bs.dropdown', cancelClose);
            hoverNavigation.addEventListener('change', function () {
                cancelClose();
                bootstrap.Dropdown.getOrCreateInstance(toggle).hide();
            });
        });
    });
    
    
    // Back to top button
    $(window).scroll(function () {
        if ($(this).scrollTop() > 100) {
            $('.back-to-top').fadeIn('slow');
        } else {
            $('.back-to-top').fadeOut('slow');
        }
    });
    $('.back-to-top').click(function () {
        $('html, body').animate({scrollTop: 0}, 1500, 'easeInOutExpo');
        return false;
    });


    // Service carousel
    $(".service-carousel").owlCarousel({
        autoplay: true,
        smartSpeed: 1500,
        dots: false,
        loop: true,
        nav : true,
        navText : [
            '<i class="fa fa-angle-left" aria-hidden="true"></i>',
            '<i class="fa fa-angle-right" aria-hidden="true"></i>'
        ],
        responsive: {
            0:{
                items:1
            },
            576:{
                items:1
            },
            768:{
                items:2
            },
            992:{
                items:2
            }
        }
    });


    // Portfolio isotope and filter
    var portfolioIsotope = $('.portfolio-container').isotope({
        itemSelector: '.portfolio-item',
        layoutMode: 'fitRows'
    });

    $('#portfolio-flters li').on('click', function () {
        $("#portfolio-flters li").removeClass('active');
        $(this).addClass('active');

        portfolioIsotope.isotope({filter: $(this).data('filter')});
    });


    // Team carousel
    $(".team-carousel").owlCarousel({
        autoplay: true,
        smartSpeed: 1500,
        dots: false,
        loop: true,
        nav : true,
        navText : [
            '<i class="fa fa-angle-left" aria-hidden="true"></i>',
            '<i class="fa fa-angle-right" aria-hidden="true"></i>'
        ],
        responsive: {
            0:{
                items:1
            },
            576:{
                items:1
            },
            768:{
                items:2
            },
            992:{
                items:3
            }
        }
    });


    // Testimonials carousel
    $(".testimonial-carousel").owlCarousel({
        autoplay: true,
        smartSpeed: 1000,
        items: 1,
        dots: false,
        loop: true,
        nav : true,
        navText : [
            '<i class="fa fa-angle-left" aria-hidden="true"></i>',
            '<i class="fa fa-angle-right" aria-hidden="true"></i>'
        ]
    });
    
})(jQuery);

