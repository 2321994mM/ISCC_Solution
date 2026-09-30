using System;
using System.Collections.Generic;
using ISCC.Infrastructure.Data.Generated;
using Microsoft.EntityFrameworkCore;

namespace ISCC.Infrastructure.Data;

public partial class PlantQuarantineDbContext : DbContext
{
    public PlantQuarantineDbContext()
    {
    }

    public PlantQuarantineDbContext(DbContextOptions<PlantQuarantineDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AAttachmentDataExCheckRequest> AAttachmentDataExCheckRequests { get; set; }

    public virtual DbSet<AAttachmentDataExCommitteeResultInfection> AAttachmentDataExCommitteeResultInfections { get; set; }

    public virtual DbSet<AAttachmentDataImCommitteeResultInfection> AAttachmentDataImCommitteeResultInfections { get; set; }

    public virtual DbSet<AAttachmentDataStation> AAttachmentDataStations { get; set; }

    public virtual DbSet<AAttachmentDatum> AAttachmentData { get; set; }

    public virtual DbSet<AAttachmentDatum1> AAttachmentData1 { get; set; }

    public virtual DbSet<AAttachmentTableName> AAttachmentTableNames { get; set; }

    public virtual DbSet<AAttachmentTableType> AAttachmentTableTypes { get; set; }

    public virtual DbSet<APlantErrorSave> APlantErrorSaves { get; set; }

    public virtual DbSet<ASystemCode> ASystemCodes { get; set; }

    public virtual DbSet<ASystemCodeType> ASystemCodeTypes { get; set; }

    public virtual DbSet<AUserLogin> AUserLogins { get; set; }

    public virtual DbSet<AnalysisLab> AnalysisLabs { get; set; }

    public virtual DbSet<AnalysisLabType> AnalysisLabTypes { get; set; }

    public virtual DbSet<AnalysisType> AnalysisTypes { get; set; }

    public virtual DbSet<AndriodLocation> AndriodLocations { get; set; }

    public virtual DbSet<AndriodOperation> AndriodOperations { get; set; }

    public virtual DbSet<BiologicalPhase> BiologicalPhases { get; set; }

    public virtual DbSet<Center> Centers { get; set; }

    public virtual DbSet<CommitteeEmployee> CommitteeEmployees { get; set; }

    public virtual DbSet<CommitteeResultType> CommitteeResultTypes { get; set; }

    public virtual DbSet<CommitteeType> CommitteeTypes { get; set; }

    public virtual DbSet<CompanyAccreditation> CompanyAccreditations { get; set; }

    public virtual DbSet<CompanyAccreditationCommittee> CompanyAccreditationCommittees { get; set; }

    public virtual DbSet<CompanyAccreditationPayment> CompanyAccreditationPayments { get; set; }

    public virtual DbSet<CompanyActivity> CompanyActivities { get; set; }

    public virtual DbSet<CompanyActivity1> CompanyActivities1 { get; set; }

    public virtual DbSet<CompanyActivityType> CompanyActivityTypes { get; set; }

    public virtual DbSet<CompanyNational> CompanyNationals { get; set; }

    public virtual DbSet<CompanyNational1> CompanyNationals1 { get; set; }

    public virtual DbSet<ContactType> ContactTypes { get; set; }

    public virtual DbSet<Continent> Continents { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<EnrollmentType> EnrollmentTypes { get; set; }

    public virtual DbSet<Ex> Exes { get; set; }

    public virtual DbSet<ExCertificateAddtion> ExCertificateAddtions { get; set; }

    public virtual DbSet<ExCertificateAddtionUser> ExCertificateAddtionUsers { get; set; }

    public virtual DbSet<ExCertificatesNewCountry> ExCertificatesNewCountries { get; set; }

    public virtual DbSet<ExCertificatesRequest> ExCertificatesRequests { get; set; }

    public virtual DbSet<ExCertificatesRequestsFile> ExCertificatesRequestsFiles { get; set; }

    public virtual DbSet<ExCertificatesRequestsLotDatum> ExCertificatesRequestsLotData { get; set; }

    public virtual DbSet<ExCertificatesRequestsPayment> ExCertificatesRequestsPayments { get; set; }

    public virtual DbSet<ExCertificatesRequestsPaymentsDetaile> ExCertificatesRequestsPaymentsDetailes { get; set; }

    public virtual DbSet<ExCertificatesRequestsPaymentsType> ExCertificatesRequestsPaymentsTypes { get; set; }

    public virtual DbSet<ExCheckRequest> ExCheckRequests { get; set; }

    public virtual DbSet<ExCheckRequestCustomsMessage> ExCheckRequestCustomsMessages { get; set; }

    public virtual DbSet<ExCheckRequestDataExtra> ExCheckRequestDataExtras { get; set; }

    public virtual DbSet<ExCheckRequestDatum> ExCheckRequestData { get; set; }

    public virtual DbSet<ExCheckRequestFee> ExCheckRequestFees { get; set; }

    public virtual DbSet<ExCheckRequestFinalResult> ExCheckRequestFinalResults { get; set; }

    public virtual DbSet<ExCheckRequestItem> ExCheckRequestItems { get; set; }

    public virtual DbSet<ExCheckRequestItemsLotCategory> ExCheckRequestItemsLotCategories { get; set; }

    public virtual DbSet<ExCheckRequestItemsLotResult> ExCheckRequestItemsLotResults { get; set; }

    public virtual DbSet<ExCheckRequestLotResultStatus> ExCheckRequestLotResultStatuses { get; set; }

    public virtual DbSet<ExCheckRequestOrganizationDistribution> ExCheckRequestOrganizationDistributions { get; set; }

    public virtual DbSet<ExCheckRequestOrganizationDistributionDetial> ExCheckRequestOrganizationDistributionDetials { get; set; }

    public virtual DbSet<ExCheckRequestOrganizationDistributionMaster> ExCheckRequestOrganizationDistributionMasters { get; set; }

    public virtual DbSet<ExCheckRequestPlace> ExCheckRequestPlaces { get; set; }

    public virtual DbSet<ExCheckRequestPort> ExCheckRequestPorts { get; set; }

    public virtual DbSet<ExCheckRequestRefuseReason> ExCheckRequestRefuseReasons { get; set; }

    public virtual DbSet<ExCheckRequestSampleDataConfirm> ExCheckRequestSampleDataConfirms { get; set; }

    public virtual DbSet<ExCheckRequestSampleDatum> ExCheckRequestSampleData { get; set; }

    public virtual DbSet<ExCheckRequestVisa> ExCheckRequestVisas { get; set; }

    public virtual DbSet<ExCheckRequsetShippingMethod> ExCheckRequsetShippingMethods { get; set; }

    public virtual DbSet<ExChooseSampleDatum> ExChooseSampleData { get; set; }

    public virtual DbSet<ExChooseTreatment> ExChooseTreatments { get; set; }

    public virtual DbSet<ExCommitteeCheckLocation> ExCommitteeCheckLocations { get; set; }

    public virtual DbSet<ExCommitteeResult> ExCommitteeResults { get; set; }

    public virtual DbSet<ExCommitteeResultConfirm> ExCommitteeResultConfirms { get; set; }

    public virtual DbSet<ExCommitteeResultInfection> ExCommitteeResultInfections { get; set; }

    public virtual DbSet<ExConstrainCountryItem> ExConstrainCountryItems { get; set; }

    public virtual DbSet<ExConstrainText> ExConstrainTexts { get; set; }

    public virtual DbSet<ExConstrainType> ExConstrainTypes { get; set; }

    public virtual DbSet<ExConstran> ExConstrans { get; set; }

    public virtual DbSet<ExContactDatum> ExContactData { get; set; }

    public virtual DbSet<ExContactDatum1> ExContactData1 { get; set; }

    public virtual DbSet<ExCountryConstrain> ExCountryConstrains { get; set; }

    public virtual DbSet<ExCountryConstrainAnalysisLabType> ExCountryConstrainAnalysisLabTypes { get; set; }

    public virtual DbSet<ExCountryConstrainArrivalPort> ExCountryConstrainArrivalPorts { get; set; }

    public virtual DbSet<ExCountryConstrainText> ExCountryConstrainTexts { get; set; }

    public virtual DbSet<ExCountryConstrainTreatment> ExCountryConstrainTreatments { get; set; }

    public virtual DbSet<ExFeesType> ExFeesTypes { get; set; }

    public virtual DbSet<ExFinalResult> ExFinalResults { get; set; }

    public virtual DbSet<ExList> ExLists { get; set; }

    public virtual DbSet<ExList2> ExList2s { get; set; }

    public virtual DbSet<ExListOld> ExListOlds { get; set; }

    public virtual DbSet<ExListQuick> ExListQuicks { get; set; }

    public virtual DbSet<ExOpertaionType> ExOpertaionTypes { get; set; }

    public virtual DbSet<ExRequestCommittee> ExRequestCommittees { get; set; }

    public virtual DbSet<ExRequestCommitteeFeesEng> ExRequestCommitteeFeesEngs { get; set; }

    public virtual DbSet<ExRequestCommitteeShift> ExRequestCommitteeShifts { get; set; }

    public virtual DbSet<ExRequestTreatmentDataConfirm> ExRequestTreatmentDataConfirms { get; set; }

    public virtual DbSet<ExRequestTreatmentDatum> ExRequestTreatmentData { get; set; }

    public virtual DbSet<ExVisa> ExVisas { get; set; }

    public virtual DbSet<Family> Families { get; set; }

    public virtual DbSet<FarmCheckList> FarmCheckLists { get; set; }

    public virtual DbSet<FarmCommittee> FarmCommittees { get; set; }

    public virtual DbSet<FarmCommitteeCheckList> FarmCommitteeCheckLists { get; set; }

    public virtual DbSet<FarmCommitteeCheckListConfirm> FarmCommitteeCheckListConfirms { get; set; }

    public virtual DbSet<FarmCommitteeConstrain> FarmCommitteeConstrains { get; set; }

    public virtual DbSet<FarmCommitteeExamination> FarmCommitteeExaminations { get; set; }

    public virtual DbSet<FarmCommitteeExaminationConfirm> FarmCommitteeExaminationConfirms { get; set; }

    public virtual DbSet<FarmCommitteeFinalResult> FarmCommitteeFinalResults { get; set; }

    public virtual DbSet<FarmCommitteeShift> FarmCommitteeShifts { get; set; }

    public virtual DbSet<FarmCompany> FarmCompanies { get; set; }

    public virtual DbSet<FarmConstrain> FarmConstrains { get; set; }

    public virtual DbSet<FarmConstrainText> FarmConstrainTexts { get; set; }

    public virtual DbSet<FarmCountry> FarmCountries { get; set; }

    public virtual DbSet<FarmCountryCheckList> FarmCountryCheckLists { get; set; }

    public virtual DbSet<FarmFee> FarmFees { get; set; }

    public virtual DbSet<FarmItemCategory> FarmItemCategories { get; set; }

    public virtual DbSet<FarmRequest> FarmRequests { get; set; }

    public virtual DbSet<FarmRequestItemCategory> FarmRequestItemCategories { get; set; }

    public virtual DbSet<FarmRequestRefuseReason> FarmRequestRefuseReasons { get; set; }

    public virtual DbSet<FarmRequestType> FarmRequestTypes { get; set; }

    public virtual DbSet<FarmSampleDataConfirm> FarmSampleDataConfirms { get; set; }

    public virtual DbSet<FarmSampleDataConfirmItem> FarmSampleDataConfirmItems { get; set; }

    public virtual DbSet<FarmSampleDataItem> FarmSampleDataItems { get; set; }

    public virtual DbSet<FarmSampleDatum> FarmSampleData { get; set; }

    public virtual DbSet<FarmStop> FarmStops { get; set; }

    public virtual DbSet<FarmsDatum> FarmsData { get; set; }

    public virtual DbSet<FarmsOrganizationDistributionDetial> FarmsOrganizationDistributionDetials { get; set; }

    public virtual DbSet<FarmsOrganizationDistributionMaster> FarmsOrganizationDistributionMasters { get; set; }

    public virtual DbSet<FeesAction> FeesActions { get; set; }

    public virtual DbSet<FeesAltahsil> FeesAltahsils { get; set; }

    public virtual DbSet<FeesAltahsilDetile> FeesAltahsilDetiles { get; set; }

    public virtual DbSet<FeesAmountFixed> FeesAmountFixeds { get; set; }

    public virtual DbSet<FeesCertificatesPaymentDetile> FeesCertificatesPaymentDetiles { get; set; }

    public virtual DbSet<FeesMoney> FeesMoneys { get; set; }

    public virtual DbSet<FeesProcess> FeesProcesses { get; set; }

    public virtual DbSet<FeesTableName> FeesTableNames { get; set; }

    public virtual DbSet<FeesTransaction> FeesTransactions { get; set; }

    public virtual DbSet<FeesTransactionsDetile> FeesTransactionsDetiles { get; set; }

    public virtual DbSet<FeesTransactionsPaymentDetile> FeesTransactionsPaymentDetiles { get; set; }

    public virtual DbSet<FeesType> FeesTypes { get; set; }

    public virtual DbSet<FeesTypeAction> FeesTypeActions { get; set; }

    public virtual DbSet<FreeZone> FreeZones { get; set; }

    public virtual DbSet<FumigationUnit> FumigationUnits { get; set; }

    public virtual DbSet<GasImportCompany> GasImportCompanies { get; set; }

    public virtual DbSet<GeneralAdmin> GeneralAdmins { get; set; }

    public virtual DbSet<Governate> Governates { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<HagrContact> HagrContacts { get; set; }

    public virtual DbSet<ImCheckRequest> ImCheckRequests { get; set; }

    public virtual DbSet<ImCheckRequestCustomsMessage> ImCheckRequestCustomsMessages { get; set; }

    public virtual DbSet<ImCheckRequestDataExtra> ImCheckRequestDataExtras { get; set; }

    public virtual DbSet<ImCheckRequestDatum> ImCheckRequestData { get; set; }

    public virtual DbSet<ImCheckRequestDistribution> ImCheckRequestDistributions { get; set; }

    public virtual DbSet<ImCheckRequestFinalResult> ImCheckRequestFinalResults { get; set; }

    public virtual DbSet<ImCheckRequestItem> ImCheckRequestItems { get; set; }

    public virtual DbSet<ImCheckRequestItemsLotCategory> ImCheckRequestItemsLotCategories { get; set; }

    public virtual DbSet<ImCheckRequestItemsLotResult> ImCheckRequestItemsLotResults { get; set; }

    public virtual DbSet<ImCheckRequestLotResultStatus> ImCheckRequestLotResultStatuses { get; set; }

    public virtual DbSet<ImCheckRequestManafest> ImCheckRequestManafests { get; set; }

    public virtual DbSet<ImCheckRequestPort> ImCheckRequestPorts { get; set; }

    public virtual DbSet<ImCheckRequestRefuseReason> ImCheckRequestRefuseReasons { get; set; }

    public virtual DbSet<ImCheckRequestSampleDataConfirm> ImCheckRequestSampleDataConfirms { get; set; }

    public virtual DbSet<ImCheckRequestSampleDatum> ImCheckRequestSampleData { get; set; }

    public virtual DbSet<ImCheckRequestVisa> ImCheckRequestVisas { get; set; }

    public virtual DbSet<ImCheckRequsetShippingMethod> ImCheckRequsetShippingMethods { get; set; }

    public virtual DbSet<ImChooseConstrain> ImChooseConstrains { get; set; }

    public virtual DbSet<ImCommitteeCheckLocation> ImCommitteeCheckLocations { get; set; }

    public virtual DbSet<ImCommitteeCustodyPlace> ImCommitteeCustodyPlaces { get; set; }

    public virtual DbSet<ImCommitteeResult> ImCommitteeResults { get; set; }

    public virtual DbSet<ImCommitteeResultConfirm> ImCommitteeResultConfirms { get; set; }

    public virtual DbSet<ImCommitteeResultInfection> ImCommitteeResultInfections { get; set; }

    public virtual DbSet<ImConstrainInitiatorText> ImConstrainInitiatorTexts { get; set; }

    public virtual DbSet<ImConstrainType> ImConstrainTypes { get; set; }

    public virtual DbSet<ImConstrainsSpecial> ImConstrainsSpecials { get; set; }

    public virtual DbSet<ImCountryConstrainArrivalPort> ImCountryConstrainArrivalPorts { get; set; }

    public virtual DbSet<ImCountryConstrainText> ImCountryConstrainTexts { get; set; }

    public virtual DbSet<ImCustodyPlace> ImCustodyPlaces { get; set; }

    public virtual DbSet<ImCustodyPlaceCheckRequest> ImCustodyPlaceCheckRequests { get; set; }

    public virtual DbSet<ImCustodyPlaceType> ImCustodyPlaceTypes { get; set; }

    public virtual DbSet<ImExecution> ImExecutions { get; set; }

    public virtual DbSet<ImExecutionItem> ImExecutionItems { get; set; }

    public virtual DbSet<ImFinalResult> ImFinalResults { get; set; }

    public virtual DbSet<ImFumigation> ImFumigations { get; set; }

    public virtual DbSet<ImFumigationDistribution> ImFumigationDistributions { get; set; }

    public virtual DbSet<ImFumigationDistributionInspection> ImFumigationDistributionInspections { get; set; }

    public virtual DbSet<ImFumigationDistributionMessage> ImFumigationDistributionMessages { get; set; }

    public virtual DbSet<ImFumigationDistributionMessageRead> ImFumigationDistributionMessageReads { get; set; }

    public virtual DbSet<ImFumigationDistributionResult> ImFumigationDistributionResults { get; set; }

    public virtual DbSet<ImFumigationReleaseRequest> ImFumigationReleaseRequests { get; set; }

    public virtual DbSet<ImInitiator> ImInitiators { get; set; }

    public virtual DbSet<ImItemsLotDivision> ImItemsLotDivisions { get; set; }

    public virtual DbSet<ImManafest> ImManafests { get; set; }

    public virtual DbSet<ImOpertaionType> ImOpertaionTypes { get; set; }

    public virtual DbSet<ImPermissionItem> ImPermissionItems { get; set; }

    public virtual DbSet<ImPermissionItemDivisionCustody> ImPermissionItemDivisionCustodies { get; set; }

    public virtual DbSet<ImPermissionItemDivisionCustodyDismissCommittee> ImPermissionItemDivisionCustodyDismissCommittees { get; set; }

    public virtual DbSet<ImPermissionItemDivisionCustodyReceiveCommittee> ImPermissionItemDivisionCustodyReceiveCommittees { get; set; }

    public virtual DbSet<ImPermissionItemsCategory> ImPermissionItemsCategories { get; set; }

    public virtual DbSet<ImPermissionRequest> ImPermissionRequests { get; set; }

    public virtual DbSet<ImPermissionRequestHistory> ImPermissionRequestHistories { get; set; }

    public virtual DbSet<ImPermissionRequestRefuseReason> ImPermissionRequestRefuseReasons { get; set; }

    public virtual DbSet<ImProcedureType> ImProcedureTypes { get; set; }

    public virtual DbSet<ImRequestCommittee> ImRequestCommittees { get; set; }

    public virtual DbSet<ImRequestCommitteeProcedure> ImRequestCommitteeProcedures { get; set; }

    public virtual DbSet<ImRequestCommitteeShift> ImRequestCommitteeShifts { get; set; }

    public virtual DbSet<ImRequestDatExtra> ImRequestDatExtras { get; set; }

    public virtual DbSet<ImRequestDatum> ImRequestData { get; set; }

    public virtual DbSet<ImRequestPort> ImRequestPorts { get; set; }

    public virtual DbSet<ImRequestTreatmentDataConfirm> ImRequestTreatmentDataConfirms { get; set; }

    public virtual DbSet<ImRequestTreatmentDatum> ImRequestTreatmentData { get; set; }

    public virtual DbSet<ImSampleBarcodeMonthlyCounter> ImSampleBarcodeMonthlyCounters { get; set; }

    public virtual DbSet<ImScientificResearch> ImScientificResearches { get; set; }

    public virtual DbSet<ImScientificResearchItemPlantInseketLieble> ImScientificResearchItemPlantInseketLiebles { get; set; }

    public virtual DbSet<ImScientificResearchItemPlantProduct> ImScientificResearchItemPlantProducts { get; set; }

    public virtual DbSet<ImScientificResearchOrganization> ImScientificResearchOrganizations { get; set; }

    public virtual DbSet<ImScientificResearchPerson> ImScientificResearchPeople { get; set; }

    public virtual DbSet<ImStore> ImStores { get; set; }

    public virtual DbSet<ImSubDivission> ImSubDivissions { get; set; }

    public virtual DbSet<ImTransUnderCustodyReason> ImTransUnderCustodyReasons { get; set; }

    public virtual DbSet<ImVisa> ImVisas { get; set; }

    public virtual DbSet<ImWarehouse> ImWarehouses { get; set; }

    public virtual DbSet<InternationalTransportation> InternationalTransportations { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemCategoriesGroup> ItemCategoriesGroups { get; set; }

    public virtual DbSet<ItemCategoriesType> ItemCategoriesTypes { get; set; }

    public virtual DbSet<ItemCategory> ItemCategories { get; set; }

    public virtual DbSet<ItemPart> ItemParts { get; set; }

    public virtual DbSet<ItemPurpose> ItemPurposes { get; set; }

    public virtual DbSet<ItemShortName> ItemShortNames { get; set; }

    public virtual DbSet<ItemStatus> ItemStatuses { get; set; }

    public virtual DbSet<ItemType> ItemTypes { get; set; }

    public virtual DbSet<Kingdom> Kingdoms { get; set; }

    public virtual DbSet<Level> Levels { get; set; }

    public virtual DbSet<LiableItem> LiableItems { get; set; }

    public virtual DbSet<LiableItemsShortName> LiableItemsShortNames { get; set; }

    public virtual DbSet<LiableItemsStatus> LiableItemsStatuses { get; set; }

    public virtual DbSet<MainCalssification> MainCalssifications { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Outlet> Outlets { get; set; }

    public virtual DbSet<OutletEmployee> OutletEmployees { get; set; }

    public virtual DbSet<PackageMaterial> PackageMaterials { get; set; }

    public virtual DbSet<PackageType> PackageTypes { get; set; }

    public virtual DbSet<PalletDataExCheckRequestDistribution> PalletDataExCheckRequestDistributions { get; set; }

    public virtual DbSet<PalletDataOrganizationDistribution> PalletDataOrganizationDistributions { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<PhylumSubphylum> PhylumSubphylums { get; set; }

    public virtual DbSet<PortInternational> PortInternationals { get; set; }

    public virtual DbSet<PortNational> PortNationals { get; set; }

    public virtual DbSet<PortOrganization> PortOrganizations { get; set; }

    public virtual DbSet<PortType> PortTypes { get; set; }

    public virtual DbSet<PosInformation> PosInformations { get; set; }

    public virtual DbSet<PublicOrganization> PublicOrganizations { get; set; }

    public virtual DbSet<PublicOrganizationType> PublicOrganizationTypes { get; set; }

    public virtual DbSet<QualitativeGroup> QualitativeGroups { get; set; }

    public virtual DbSet<RefuseReason> RefuseReasons { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<RegionalArea> RegionalAreas { get; set; }

    public virtual DbSet<SecondaryClassification> SecondaryClassifications { get; set; }

    public virtual DbSet<ShiftTiming> ShiftTimings { get; set; }

    public virtual DbSet<ShipmentMean> ShipmentMeans { get; set; }

    public virtual DbSet<ShippingAgency> ShippingAgencies { get; set; }

    public virtual DbSet<ShippingCompany> ShippingCompanies { get; set; }

    public virtual DbSet<Station> Stations { get; set; }

    public virtual DbSet<StationAccreditation> StationAccreditations { get; set; }

    public virtual DbSet<StationAccreditationCheckList> StationAccreditationCheckLists { get; set; }

    public virtual DbSet<StationAccreditationCommittee> StationAccreditationCommittees { get; set; }

    public virtual DbSet<StationAccreditationCommitteeCheckList> StationAccreditationCommitteeCheckLists { get; set; }

    public virtual DbSet<StationAccreditationCommitteeCheckListConfirm> StationAccreditationCommitteeCheckListConfirms { get; set; }

    public virtual DbSet<StationAccreditationCommitteeFinalResult> StationAccreditationCommitteeFinalResults { get; set; }

    public virtual DbSet<StationAccreditationCommitteeImge> StationAccreditationCommitteeImges { get; set; }

    public virtual DbSet<StationAccreditationCommitteeShift> StationAccreditationCommitteeShifts { get; set; }

    public virtual DbSet<StationAccreditationDataCountry> StationAccreditationDataCountries { get; set; }

    public virtual DbSet<StationAccreditationDataItemShortName> StationAccreditationDataItemShortNames { get; set; }

    public virtual DbSet<StationAccreditationDatum> StationAccreditationData { get; set; }

    public virtual DbSet<StationAccreditationRequest> StationAccreditationRequests { get; set; }

    public virtual DbSet<StationAccreditationRequestFee> StationAccreditationRequestFees { get; set; }

    public virtual DbSet<StationAccreditationRequestFeesEng> StationAccreditationRequestFeesEngs { get; set; }

    public virtual DbSet<StationAccreditationRequestType> StationAccreditationRequestTypes { get; set; }

    public virtual DbSet<StationActivityType> StationActivityTypes { get; set; }

    public virtual DbSet<StationCheckList> StationCheckLists { get; set; }

    public virtual DbSet<StationCommittee> StationCommittees { get; set; }

    public virtual DbSet<StationCompany> StationCompanies { get; set; }

    public virtual DbSet<StationConstrainCountryItem> StationConstrainCountryItems { get; set; }

    public virtual DbSet<StationConstrainType> StationConstrainTypes { get; set; }

    public virtual DbSet<StationContact> StationContacts { get; set; }

    public virtual DbSet<StationDatum> StationData { get; set; }

    public virtual DbSet<StationEmp> StationEmps { get; set; }

    public virtual DbSet<StationFeesType> StationFeesTypes { get; set; }

    public virtual DbSet<StationList> StationLists { get; set; }

    public virtual DbSet<StationManagingDirector> StationManagingDirectors { get; set; }

    public virtual DbSet<StationRequst> StationRequsts { get; set; }

    public virtual DbSet<SteamingCompany> SteamingCompanies { get; set; }

    public virtual DbSet<SubPart> SubParts { get; set; }

    public virtual DbSet<SubPartType> SubPartTypes { get; set; }

    public virtual DbSet<TableAction> TableActions { get; set; }

    public virtual DbSet<TableActionLog> TableActionLogs { get; set; }

    public virtual DbSet<TableActionLogCheckRequest> TableActionLogCheckRequests { get; set; }

    public virtual DbSet<TableActionLogEx> TableActionLogExes { get; set; }

    public virtual DbSet<TableActionLogFarm> TableActionLogFarms { get; set; }

    public virtual DbSet<TableActionLogStation> TableActionLogStations { get; set; }

    public virtual DbSet<TransportMean> TransportMeans { get; set; }

    public virtual DbSet<TreatmentMainType> TreatmentMainTypes { get; set; }

    public virtual DbSet<TreatmentMaterial> TreatmentMaterials { get; set; }

    public virtual DbSet<TreatmentMethod> TreatmentMethods { get; set; }

    public virtual DbSet<TreatmentType> TreatmentTypes { get; set; }

    public virtual DbSet<Union> Unions { get; set; }

    public virtual DbSet<UnionCountry> UnionCountries { get; set; }

    public virtual DbSet<UnitType> UnitTypes { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    public virtual DbSet<ViewListImPermissionRequest> ViewListImPermissionRequests { get; set; }

    public virtual DbSet<Village> Villages { get; set; }

    public virtual DbSet<VwImFumigationCompletedLot> VwImFumigationCompletedLots { get; set; }

    public virtual DbSet<VwImFumigationDistributionMessageAccess> VwImFumigationDistributionMessageAccesses { get; set; }

    public virtual DbSet<VwImFumigationRequestMetadatum> VwImFumigationRequestMetadata { get; set; }

    public virtual DbSet<WebsiteTypeDetail> WebsiteTypeDetails { get; set; }

    public virtual DbSet<Websitetype> Websitetypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AAttachmentDataExCheckRequest>(entity =>
        {
            entity.ToTable("A_AttachmentData_Ex_CheckRequest");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AAttachmentTableNameId).HasColumnName("A_AttachmentTableNameId");
            entity.Property(e => e.AAttachmentTableTypeId).HasColumnName("A_AttachmentTableType_ID");
            entity.Property(e => e.AttachmentNumber).HasColumnName("Attachment_Number");
            entity.Property(e => e.AttachmentPathBinary)
                .HasMaxLength(7000)
                .IsFixedLength()
                .HasColumnName("AttachmentPath_Binary");
            entity.Property(e => e.AttachmentTypeName)
                .HasComment("نوع المرفق")
                .HasColumnName("Attachment_TypeName");
            entity.Property(e => e.EndDate)
                .HasComment("تاريخ النهاية")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.ExCheckRequestId).HasColumnName("Ex_CheckRequest_ID");
            entity.Property(e => e.StartDate)
                .HasComment("تاريخ البداية")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId)
                .HasComment("null-> for user , value -> if the admin add the row")
                .HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.AAttachmentTableName).WithMany(p => p.AAttachmentDataExCheckRequests)
                .HasForeignKey(d => d.AAttachmentTableNameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_A_AttachmentData_Ex_CheckRequest_A_AttachmentTableName");

            entity.HasOne(d => d.AAttachmentTableType).WithMany(p => p.AAttachmentDataExCheckRequests)
                .HasForeignKey(d => d.AAttachmentTableTypeId)
                .HasConstraintName("FK_A_AttachmentData_Ex_CheckRequest_A_AttachmentTableType");
        });

        modelBuilder.Entity<AAttachmentDataExCommitteeResultInfection>(entity =>
        {
            entity.ToTable("A_AttachmentData_Ex_CommitteeResult_Infection");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AttachmentPathBinary).HasColumnName("AttachmentPath_Binary");
            entity.Property(e => e.ExCommitteeResultId).HasColumnName("Ex_CommitteeResult_id");
            entity.Property(e => e.InfectionComment).HasColumnName("Infection_Comment");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");

            entity.HasOne(d => d.ExCommitteeResult).WithMany(p => p.AAttachmentDataExCommitteeResultInfections)
                .HasForeignKey(d => d.ExCommitteeResultId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_A_AttachmentData_Ex_CommitteeResult_Infection_Ex_CommitteeResult");
        });

        modelBuilder.Entity<AAttachmentDataImCommitteeResultInfection>(entity =>
        {
            entity.ToTable("A_AttachmentData_Im_CommitteeResult_Infection", tb => tb.HasComment("صور فحص الاصابه"));

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AttachmentPathBinary).HasColumnName("AttachmentPath_Binary");
            entity.Property(e => e.ImCommitteeResultId).HasColumnName("Im_CommitteeResult_id");
            entity.Property(e => e.InfectionComment)
                .HasComment("نوع المرفق")
                .HasColumnName("Infection_Comment");
            entity.Property(e => e.UserCreationDate)
                .HasComment("null-> for user , value -> if the admin add the row")
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId)
                .HasComment("null-> for user , value -> if the admin add the row")
                .HasColumnName("User_Creation_Id");

            entity.HasOne(d => d.ImCommitteeResult).WithMany(p => p.AAttachmentDataImCommitteeResultInfections)
                .HasForeignKey(d => d.ImCommitteeResultId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_A_AttachmentData_Im_CommitteeResult_Infection_Im_CommitteeResult");
        });

        modelBuilder.Entity<AAttachmentDataStation>(entity =>
        {
            entity.ToTable("A_AttachmentData_Station", tb => tb.HasComment("اسم الجدول"));

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AAttachmentTableNameId)
                .HasComment("اسم الجدول")
                .HasColumnName("A_AttachmentTableNameId");
            entity.Property(e => e.AAttachmentTableTypeId)
                .HasComment("نوع المرفق")
                .HasColumnName("A_AttachmentTableType_ID");
            entity.Property(e => e.AttachmentNumber)
                .HasComment("رقم المرفق")
                .HasColumnName("Attachment_Number");
            entity.Property(e => e.AttachmentPath).HasComment("مسار المرفق");
            entity.Property(e => e.AttachmentPathBinary)
                .HasMaxLength(7000)
                .IsFixedLength()
                .HasColumnName("AttachmentPath_Binary");
            entity.Property(e => e.AttachmentTypeName)
                .HasComment("اسم المرفق")
                .HasColumnName("Attachment_TypeName");
            entity.Property(e => e.EndDate)
                .HasComment("تاريخ النهاية")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.RowId).HasComment("الرقم داخل الجدول");
            entity.Property(e => e.StartDate)
                .HasComment("تاريخ البداية")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.UserCreationDate)
                .HasComment("null-> for user , value -> if the admin add the row")
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId)
                .HasComment("null-> for user , value -> if the admin add the row")
                .HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.AAttachmentTableName).WithMany(p => p.AAttachmentDataStations)
                .HasForeignKey(d => d.AAttachmentTableNameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_A_AttachmentData_Station_A_AttachmentTableName");

            entity.HasOne(d => d.AAttachmentTableType).WithMany(p => p.AAttachmentDataStations)
                .HasForeignKey(d => d.AAttachmentTableTypeId)
                .HasConstraintName("FK_A_AttachmentData_Station_A_AttachmentTableType");
        });

        modelBuilder.Entity<AAttachmentDatum>(entity =>
        {
            entity.ToTable("A_AttachmentData", tb => tb.HasComment("باص الملفات"));

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AAttachmentTableNameId).HasColumnName("A_AttachmentTableNameId");
            entity.Property(e => e.AAttachmentTableTypeId).HasColumnName("A_AttachmentTableType_ID");
            entity.Property(e => e.AttachmentNumber).HasColumnName("Attachment_Number");
            entity.Property(e => e.AttachmentPathBinary)
                .HasMaxLength(7000)
                .IsFixedLength()
                .HasColumnName("AttachmentPath_Binary");
            entity.Property(e => e.AttachmentTypeName)
                .HasComment("نوع المرفق")
                .HasColumnName("Attachment_TypeName");
            entity.Property(e => e.EndDate)
                .HasComment("تاريخ النهاية")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.StartDate)
                .HasComment("تاريخ البداية")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.UserCreationDate)
                .HasComment("null-> for user , value -> if the admin add the row")
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId)
                .HasComment("null-> for user , value -> if the admin add the row")
                .HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.AAttachmentTableName).WithMany(p => p.AAttachmentData)
                .HasForeignKey(d => d.AAttachmentTableNameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_A_AttachmentData_A_AttachmentTableName");

            entity.HasOne(d => d.AAttachmentTableType).WithMany(p => p.AAttachmentData)
                .HasForeignKey(d => d.AAttachmentTableTypeId)
                .HasConstraintName("FK_A_AttachmentData_A_AttachmentTableType");
        });

        modelBuilder.Entity<AAttachmentDatum1>(entity =>
        {
            entity.ToTable("A_AttachmentData", "rejection");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AAttachmentTableNameId).HasColumnName("A_AttachmentTableNameId");
            entity.Property(e => e.AttachmentNumber).HasColumnName("Attachment_Number");
            entity.Property(e => e.AttachmentPathBinary)
                .HasMaxLength(7000)
                .IsFixedLength()
                .HasColumnName("AttachmentPath_Binary");
            entity.Property(e => e.AttachmentTypeName).HasColumnName("Attachment_TypeName");
            entity.Property(e => e.EndDate).HasColumnType("smalldatetime");
            entity.Property(e => e.StartDate).HasColumnType("smalldatetime");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<AAttachmentTableName>(entity =>
        {
            entity.ToTable("A_AttachmentTableName", tb => tb.HasComment("اسماء الجداول فى قواعد البيانات"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(150);
            entity.Property(e => e.PrModuleId).HasColumnName("PR_Module_ID");
            entity.Property(e => e.TableName).HasMaxLength(100);
        });

        modelBuilder.Entity<AAttachmentTableType>(entity =>
        {
            entity.ToTable("A_AttachmentTableType", tb => tb.HasComment("نوع المرفق"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ArName).HasColumnName("Ar_Name");
            entity.Property(e => e.EnName).HasColumnName("En_Name");
            entity.Property(e => e.OprationTypeAttachment).HasColumnName("opration_type_attachment");
        });

        modelBuilder.Entity<APlantErrorSave>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_plant_Error_Save");

            entity.ToTable("A__plant_Error_Save");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.ErrorMessage).IsUnicode(false);
            entity.Property(e => e.FunctionName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.IsWeb).HasComment("1->web, 0->android");
            entity.Property(e => e.PageName).IsUnicode(false);
            entity.Property(e => e.UserIp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("User_Ip");
        });

        modelBuilder.Entity<ASystemCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SystemCode");

            entity.ToTable("A_SystemCode");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ValueName).HasMaxLength(150);
            entity.Property(e => e.ValueNameEn)
                .HasMaxLength(150)
                .HasColumnName("ValueNameEN");

            entity.HasOne(d => d.SystemCodeType).WithMany(p => p.ASystemCodes)
                .HasForeignKey(d => d.SystemCodeTypeId)
                .HasConstraintName("FK_SystemCode_SystemCodeType");
        });

        modelBuilder.Entity<ASystemCodeType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SystemCodeType");

            entity.ToTable("A_SystemCodeType");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(150);
            entity.Property(e => e.TableName).HasMaxLength(100);
        });

        modelBuilder.Entity<AUserLogin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_A_User_Login");

            entity.ToTable("A__User_Login");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AccessToken)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LogOutDate)
                .HasColumnType("datetime")
                .HasColumnName("LogOut_Date");
            entity.Property(e => e.LoginDate)
                .HasColumnType("datetime")
                .HasColumnName("Login_Date");
            entity.Property(e => e.UserId).HasColumnName("User_Id");
        });

        modelBuilder.Entity<AnalysisLab>(entity =>
        {
            entity.ToTable("AnalysisLab", tb => tb.HasComment("معامل التحاليل"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AddreesAr).HasColumnName("Addrees_Ar");
            entity.Property(e => e.AddreesEn)
                .IsUnicode(false)
                .HasColumnName("Addrees_En");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fax).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Name_En");
            entity.Property(e => e.Phone).HasColumnType("numeric(11, 0)");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<AnalysisLabType>(entity =>
        {
            entity.ToTable("AnalysisLabType", tb => tb.HasComment("جدول ربط التحاليل بالمعامل"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AnalysisLabId).HasColumnName("AnalysisLabID");
            entity.Property(e => e.AnalysisTypeId).HasColumnName("AnalysisTypeID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.AnalysisLab).WithMany(p => p.AnalysisLabTypes)
                .HasForeignKey(d => d.AnalysisLabId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AnalysisLabType_AnalysisLab");

            entity.HasOne(d => d.AnalysisType).WithMany(p => p.AnalysisLabTypes)
                .HasForeignKey(d => d.AnalysisTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AnalysisLabType_AnalysisType");
        });

        modelBuilder.Entity<AnalysisType>(entity =>
        {
            entity.ToTable("AnalysisType", tb => tb.HasComment("التحاليل التي تتم على العينة"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsRejectedAll).HasComment("هل يرفض الطلب كله في حالة وجود إصابة");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Name_En");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<AndriodLocation>(entity =>
        {
            entity.ToTable("Andriod_Location");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CommitteId).HasColumnName("Committe_ID");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.IsExport)
                .HasDefaultValue(true)
                .HasComment("1->Export , 0->Import");
            entity.Property(e => e.OperationId)
                .HasComment("the action that user made 'Export, Treatment, Sample Data, ....")
                .HasColumnName("Operation_ID");
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.Operation).WithMany(p => p.AndriodLocations)
                .HasForeignKey(d => d.OperationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Andriod_Location_Andriod_Operation");
        });

        modelBuilder.Entity<AndriodOperation>(entity =>
        {
            entity.ToTable("Andriod_Operation");

            entity.Property(e => e.OperationName)
                .HasMaxLength(50)
                .HasColumnName("Operation_Name");
        });

        modelBuilder.Entity<BiologicalPhase>(entity =>
        {
            entity.ToTable("Biological_Phase", tb => tb.HasComment("الطور الحيوي"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Name_En");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<Center>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_LK_Center");

            entity.ToTable("Center", tb => tb.HasComment("المراكز"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ArName)
                .HasMaxLength(150)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Ar_Name");
            entity.Property(e => e.EnName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("En_Name");
            entity.Property(e => e.GovernId)
                .HasComment("المحافظة")
                .HasColumnName("Govern_ID");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasComment("مفعل");
            entity.Property(e => e.OutletId)
                .HasComment("المنافذ")
                .HasColumnName("Outlet_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.Govern).WithMany(p => p.Centers)
                .HasForeignKey(d => d.GovernId)
                .HasConstraintName("FK_Center_Governate");

            entity.HasOne(d => d.Outlet).WithMany(p => p.Centers)
                .HasForeignKey(d => d.OutletId)
                .HasConstraintName("FK_Center_Outlet");
        });

        modelBuilder.Entity<CommitteeEmployee>(entity =>
        {
            entity.HasKey(e => new { e.CommitteeId, e.EmployeeId, e.OperationType });

            entity.ToTable("CommitteeEmployee", tb => tb.HasComment("أعضاء اللجنة"));

            entity.Property(e => e.CommitteeId).HasColumnName("Committee_ID");
            entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");
            entity.Property(e => e.OperationType).HasComment("from system code 20 (export :73 , Import 74, Farm 78) ");
            entity.Property(e => e.Isadmin)
                .HasComment("is admin for the current committee")
                .HasColumnName("ISAdmin");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");

            entity.HasOne(d => d.OperationTypeNavigation).WithMany(p => p.CommitteeEmployees)
                .HasForeignKey(d => d.OperationType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CommitteeEmployee_A_SystemCode");
        });

        modelBuilder.Entity<CommitteeResultType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CommitteeResult");

            entity.ToTable("CommitteeResultType", tb => tb.HasComment("مرفوض/ مقبول .........."));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.NameAr)
                .HasMaxLength(20)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Name_En");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<CommitteeType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CommitteePurpose");

            entity.ToTable("CommitteeType", tb => tb.HasComment("الغرض من اللجنة"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name_En");
            entity.Property(e => e.TypeId)
                .HasDefaultValue(93)
                .HasColumnName("type_Id");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.Type).WithMany(p => p.CommitteeTypes)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("FK__Committee__type___34D49220");
        });

        modelBuilder.Entity<CompanyAccreditation>(entity =>
        {
            entity.ToTable("CompanyAccreditation", tb => tb.HasComment("اعتمادات الشركة"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CompanyId)
                .HasComment("الشركة")
                .HasColumnName("Company_ID");
            entity.Property(e => e.CountryId)
                .HasComment("الدولة")
                .HasColumnName("Country_ID");
            entity.Property(e => e.EndDate).HasComment("تاريخ نهاية الاعتماد");
            entity.Property(e => e.IsApproved).HasComment("null->ask for accredation\r\n0->not accepted\r\n1->Accepted");
            entity.Property(e => e.ItemShortNameId)
                .HasComment("product or plant ID manual no relation")
                .HasColumnName("Item_ShortName_id");
            entity.Property(e => e.StartDate).HasComment("تاريخ بداية الاعتماد");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.Company).WithMany(p => p.CompanyAccreditations)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_CompanyAccreditation_Companies");

            entity.HasOne(d => d.Country).WithMany(p => p.CompanyAccreditations)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_CompanyAccreditation_Country");

            entity.HasOne(d => d.ItemShortName).WithMany(p => p.CompanyAccreditations)
                .HasForeignKey(d => d.ItemShortNameId)
                .HasConstraintName("FK_CompanyAccreditation_Item_ShortName");
        });

        modelBuilder.Entity<CompanyAccreditationCommittee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Company_Committee");

            entity.ToTable("CompanyAccreditation_Committee");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AmountTotal)
                .HasComment("المبلغ")
                .HasColumnType("money")
                .HasColumnName("Amount_Total");
            entity.Property(e => e.CheckDate)
                .HasComment("تاريخ الانتداب")
                .HasColumnName("Check_Date");
            entity.Property(e => e.CommitteeTypeId).HasColumnName("CommitteeType_ID");
            entity.Property(e => e.CompanyAccreditationId)
                .HasComment("طلب الفحص")
                .HasColumnName("Company_Accreditation_ID");
            entity.Property(e => e.DelegationDate)
                .HasComment("تاريخ الفحص")
                .HasColumnName("Delegation_Date");
            entity.Property(e => e.EndTime).HasComment("انتهاء ساعة الفحص");
            entity.Property(e => e.IsApproved).HasComment("0 if exporter doesn't accept else 1");
            entity.Property(e => e.IsPaid).HasComment("تم الانتهاء من الدفع");
            entity.Property(e => e.StartTime).HasComment(" بداية ساعة الفحص ");
            entity.Property(e => e.Status)
                .HasDefaultValue(false)
                .HasComment("null->No committe ,0 if not done, 1 if investigation is done");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.CommitteeType).WithMany(p => p.CompanyAccreditationCommittees)
                .HasForeignKey(d => d.CommitteeTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Company_Accreditation_Committee_CommitteeType");

            entity.HasOne(d => d.CompanyAccreditation).WithMany(p => p.CompanyAccreditationCommittees)
                .HasForeignKey(d => d.CompanyAccreditationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Company_Accreditation_Committee_CompanyAccreditation");
        });

        modelBuilder.Entity<CompanyAccreditationPayment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Company_Payment");

            entity.ToTable("CompanyAccreditation_Payment");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Amount)
                .HasComment("المبلغ")
                .HasColumnType("money");
            entity.Property(e => e.CompanyCommitteeId).HasColumnName("Company_Committee_ID");
            entity.Property(e => e.IsOnlineOffline)
                .HasComment("from web/system\r\n1->online\r\n0->offline")
                .HasColumnName("IS_OnlineOffline");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");

            entity.HasOne(d => d.CompanyCommittee).WithMany(p => p.CompanyAccreditationPayments)
                .HasForeignKey(d => d.CompanyCommitteeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Company_Payment_Company_Committee");
        });

        modelBuilder.Entity<CompanyActivity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CompanyActivities");

            entity.ToTable("CompanyActivity", tb => tb.HasComment("نشاط الشركة"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CompActivityTypeId)
                .HasComment("نوع النشاط")
                .HasColumnName("CompActivityType_ID");
            entity.Property(e => e.CompanyId)
                .HasComment("الشركة")
                .HasColumnName("Company_ID");
            entity.Property(e => e.EnrollmentEnd)
                .HasComment("تاريخ نهاية")
                .HasColumnName("Enrollment_End");
            entity.Property(e => e.EnrollmentName)
                .HasMaxLength(100)
                .HasColumnName("Enrollment_Name");
            entity.Property(e => e.EnrollmentNumber)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Enrollment_Number");
            entity.Property(e => e.EnrollmentStart)
                .HasComment("تاريخ بداية")
                .HasColumnName("Enrollment_Start");
            entity.Property(e => e.EnrollmentTypeId).HasColumnName("Enrollment_type_ID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.MainActivityType).HasComment("نوع نشاط الرئيسى from systemcode 17");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.CompActivityType).WithMany(p => p.CompanyActivities)
                .HasForeignKey(d => d.CompActivityTypeId)
                .HasConstraintName("FK_CompanyActivity_CompanyActivityType");

            entity.HasOne(d => d.Company).WithMany(p => p.CompanyActivities)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_CompanyActivity_Company");

            entity.HasOne(d => d.EnrollmentType).WithMany(p => p.CompanyActivities)
                .HasForeignKey(d => d.EnrollmentTypeId)
                .HasConstraintName("FK_CompanyActivity_Enrollment_type");

            entity.HasOne(d => d.MainActivityTypeNavigation).WithMany(p => p.CompanyActivities)
                .HasForeignKey(d => d.MainActivityType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompanyActivity_A_SystemCode");
        });

        modelBuilder.Entity<CompanyActivity1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CompanyActivities");

            entity.ToTable("CompanyActivity", "rejection");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CompActivityTypeId).HasColumnName("CompActivityType_ID");
            entity.Property(e => e.CompanyId).HasColumnName("Company_ID");
            entity.Property(e => e.EnrollmentEnd).HasColumnName("Enrollment_End");
            entity.Property(e => e.EnrollmentName)
                .HasMaxLength(100)
                .HasColumnName("Enrollment_Name");
            entity.Property(e => e.EnrollmentNumber)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Enrollment_Number");
            entity.Property(e => e.EnrollmentStart).HasColumnName("Enrollment_Start");
            entity.Property(e => e.EnrollmentTypeId).HasColumnName("Enrollment_type_ID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.Company).WithMany(p => p.CompanyActivity1s)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_CompanyActivity_Company");
        });

        modelBuilder.Entity<CompanyActivityType>(entity =>
        {
            entity.ToTable("CompanyActivityType", tb => tb.HasComment("نوع نشاط الشركة"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("Name_En");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<CompanyNational>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Companies");

            entity.ToTable("Company_National", tb => tb.HasComment("شركة محلية"));

            entity.HasIndex(e => e.Id, "_dta_index_Company_National_15_1931258035__K1_2_3");

            entity.HasIndex(e => new { e.TaxesRecord, e.CommertialRecord }, "uk_Company_National").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AddressAr)
                .HasComment("العنوان بالعربية")
                .HasColumnName("Address_Ar");
            entity.Property(e => e.AddressEn)
                .IsUnicode(false)
                .HasComment("العنوان بالانجليزية")
                .HasColumnName("Address_En");
            entity.Property(e => e.CenterId).HasColumnName("Center_ID");
            entity.Property(e => e.CommertialRecord)
                .HasMaxLength(200)
                .HasComment("السجل التجاري");
            entity.Property(e => e.IsApproved).HasComment("null->Company request \r\n0->not accepted\r\n1->Aceecpted\r\n ");
            entity.Property(e => e.IsOnlineOffline)
                .HasDefaultValue(false)
                .HasComment("from web/system\r\n1->online\r\n0->offline")
                .HasColumnName("IS_OnlineOffline");
            entity.Property(e => e.IsTreatment).HasComment("it was deleted and i returned it again fz 8-9-2019");
            entity.Property(e => e.NameAr)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("Name_En");
            entity.Property(e => e.OwnerAr)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Owner_Ar");
            entity.Property(e => e.OwnerEn)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("Owner_En");
            entity.Property(e => e.TaxesRecord)
                .HasMaxLength(200)
                .HasComment("السجل الضريبي");
            entity.Property(e => e.UserActivationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Activation_Date");
            entity.Property(e => e.UserActivationId).HasColumnName("User_Activation_Id");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
            entity.Property(e => e.VillageId).HasColumnName("Village_ID");

            entity.HasOne(d => d.Center).WithMany(p => p.CompanyNationals)
                .HasForeignKey(d => d.CenterId)
                .HasConstraintName("FK_Company_National_Center");

            entity.HasOne(d => d.Village).WithMany(p => p.CompanyNationals)
                .HasForeignKey(d => d.VillageId)
                .HasConstraintName("FK_Company_National_Village");
        });

        modelBuilder.Entity<CompanyNational1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Companies");

            entity.ToTable("Company_National", "rejection");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AddressAr).HasColumnName("Address_Ar");
            entity.Property(e => e.AddressEn)
                .IsUnicode(false)
                .HasColumnName("Address_En");
            entity.Property(e => e.CenterId).HasColumnName("Center_ID");
            entity.Property(e => e.CommertialRecord).HasMaxLength(200);
            entity.Property(e => e.IsOnlineOffline).HasColumnName("IS_OnlineOffline");
            entity.Property(e => e.NameAr).HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .IsUnicode(false)
                .HasColumnName("Name_En");
            entity.Property(e => e.OwnerAr).HasColumnName("Owner_Ar");
            entity.Property(e => e.OwnerEn)
                .IsUnicode(false)
                .HasColumnName("Owner_En");
            entity.Property(e => e.TaxesRecord).HasMaxLength(200);
            entity.Property(e => e.UserActivationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Activation_Date");
            entity.Property(e => e.UserActivationId).HasColumnName("User_Activation_Id");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
            entity.Property(e => e.VillageId).HasColumnName("Village_ID");
        });

        modelBuilder.Entity<ContactType>(entity =>
        {
            entity.ToTable("ContactType", tb => tb.HasComment("نوع بيان الاتصال"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("Name_En");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<Continent>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DescreptionAr).HasColumnName("Descreption_Ar");
            entity.Property(e => e.DescreptionEn)
                .IsUnicode(false)
                .HasColumnName("Descreption_En");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasComment("قارة");
            entity.Property(e => e.NameAr)
                .HasMaxLength(200)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(200)
                .HasColumnName("Name_En");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_LK_Country");

            entity.ToTable("Country", tb => tb.HasComment("الدول"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ArName)
                .HasMaxLength(100)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Ar_Name");
            entity.Property(e => e.ContinentsId).HasColumnName("Continents_ID");
            entity.Property(e => e.EnName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("En_Name");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsIppc)
                .HasDefaultValue(true)
                .HasColumnName("Is_IPPC");
            entity.Property(e => e.RegionalAreaId).HasColumnName("Regional_Area_ID");
            entity.Property(e => e.UserCreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.Continents).WithMany(p => p.Countries)
                .HasForeignKey(d => d.ContinentsId)
                .HasConstraintName("FK_Country_Continents");

            entity.HasOne(d => d.RegionalArea).WithMany(p => p.Countries)
                .HasForeignKey(d => d.RegionalAreaId)
                .HasConstraintName("FK_Country_Regional_Area");
        });

        modelBuilder.Entity<EnrollmentType>(entity =>
        {
            entity.ToTable("Enrollment_type");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ArName)
                .HasMaxLength(150)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Ar_Name");
            entity.Property(e => e.EnName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("En_Name");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasComment("مفعل");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<Ex>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("EX");

            entity.Property(e => e.CheckRequestNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CheckRequest_Number");
            entity.Property(e => e.CommitteeId).HasColumnName("Committee_ID");
            entity.Property(e => e.CommitteeTypeId).HasColumnName("CommitteeType_ID");
            entity.Property(e => e.Date).HasColumnType("smalldatetime");
            entity.Property(e => e.DelegationDate).HasColumnName("Delegation_Date");
            entity.Property(e => e.ExCheckRequestId).HasColumnName("Ex_CheckRequest_ID");
            entity.Property(e => e.ExCheckRequestItemsId).HasColumnName("Ex_CheckRequest_Items_ID");
            entity.Property(e => e.ExCommitteeResultId).HasColumnName("Ex_CommitteeResult_ID");
            entity.Property(e => e.Expr2).HasColumnType("smalldatetime");
            entity.Property(e => e.IsTotal).HasColumnName("IS_Total");
            entity.Property(e => e.ItemShortNameId).HasColumnName("Item_ShortName_ID");
            entity.Property(e => e.LotDataId).HasColumnName("LotData_ID");
            entity.Property(e => e.ShortNameAr).HasColumnName("ShortName_Ar");
            entity.Property(e => e.ShortNameEn)
                .IsUnicode(false)
                .HasColumnName("ShortName_En");
        });

        modelBuilder.Entity<ExCertificateAddtion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PlantCertificateAddtion");

            entity.ToTable("Ex_CertificateAddtion", tb => tb.HasComment("اضافات  الاشتراطات للشهادة"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AdminId)
                .HasComment("رقم موظف الحجر")
                .HasColumnName("AdminID");
            entity.Property(e => e.CertificateAddtionOriginal)
                .HasComment("نص الاشتراط الاصلى")
                .HasColumnName("Certificate_AddtionOriginal");
            entity.Property(e => e.CertificateAddtionOriginalUpdate)
                .HasComment("نص الاشتراطات بعد التعديل")
                .HasColumnName("Certificate_AddtionOriginalUpdate");
            entity.Property(e => e.CertificateAddtionUpdateAdmin)
                .HasComment("الاشتراط للحجر بعد التعديل")
                .HasColumnName("Certificate_AddtionUpdateAdmin");
            entity.Property(e => e.ConstrainId)
                .HasComment("رقم الاشتراط الاصلى")
                .HasColumnName("ConstrainID");
            entity.Property(e => e.DateAccepted)
                .HasColumnType("datetime")
                .HasColumnName("Date_Accepted");
            entity.Property(e => e.Isaccepted)
                .HasDefaultValue(false)
                .HasColumnName("ISAccepted");
            entity.Property(e => e.PlantCertificatesRequestsId).HasColumnName("PlantCertificatesRequestsID");

            entity.HasOne(d => d.PlantCertificatesRequests).WithMany(p => p.ExCertificateAddtions)
                .HasForeignKey(d => d.PlantCertificatesRequestsId)
                .HasConstraintName("FK_PlantCertificateAddtion_PlantCertificatesRequests");
        });

        modelBuilder.Entity<ExCertificateAddtionUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PlantCertificateAddtionUser");

            entity.ToTable("Ex_CertificateAddtionUser", tb => tb.HasComment("الشروط الاضافية الجديدة"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CertificateAddtionText).HasColumnName("Certificate_AddtionText");
            entity.Property(e => e.IsClientOrAgree)
                .HasComment("اضافه العميل 1 او رد الحجر 0\r\n")
                .HasColumnName("IS_Client_OR_Agree");
            entity.Property(e => e.PlantCertificatesRequestsId).HasColumnName("PlantCertificatesRequestsID");

            entity.HasOne(d => d.PlantCertificatesRequests).WithMany(p => p.ExCertificateAddtionUsers)
                .HasForeignKey(d => d.PlantCertificatesRequestsId)
                .HasConstraintName("FK_PlantCertificateAddtionUser_PlantCertificatesRequests");
        });

        modelBuilder.Entity<ExCertificatesNewCountry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PlantCertificatesNewArrivePort");

            entity.ToTable("Ex_CertificatesNewCountry", tb => tb.HasComment("طلب تغير وجهه"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ExCheckRequestId).HasColumnName("Ex_CheckRequest_ID");
            entity.Property(e => e.Isaccepted).HasColumnName("ISAccepted");
            entity.Property(e => e.OldCountryId).HasColumnName("OldCountryID");
            entity.Property(e => e.PortInternationalIdNew).HasColumnName("Port_International_ID_new");
            entity.Property(e => e.PortInternationalIdOld).HasColumnName("Port_International_ID_old");
            entity.Property(e => e.PortTypeIdNew).HasColumnName("Port_Type_ID_New");
            entity.Property(e => e.PortTypeIdOld).HasColumnName("Port_Type_ID_Old");
            entity.Property(e => e.ReqPortTypeId).HasColumnName("ReqPortType_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ExCheckRequest).WithMany(p => p.ExCertificatesNewCountries)
                .HasForeignKey(d => d.ExCheckRequestId)
                .HasConstraintName("FK_PlantCertificatesNewCountry_Ex_CheckRequest");
        });

        modelBuilder.Entity<ExCertificatesRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PlantCertificatesRequests");

            entity.ToTable("Ex_CertificatesRequests", tb => tb.HasComment("بيانات الشهادة"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ArrivePortId).HasColumnName("ArrivePortID");
            entity.Property(e => e.ExCheckRequestId).HasColumnName("Ex_CheckRequest_ID");
            entity.Property(e => e.ExporterTypeId).HasColumnName("ExporterTypeID");
            entity.Property(e => e.ImporeterCompanyAddressAr)
                .HasComment("عنوان الشركة المستوردة باللغه العربية")
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("ImporeterCompanyAddress_AR");
            entity.Property(e => e.ImporeterCompanyAddressEn)
                .HasComment("عنوان الشركة المستوردة باللغه الأنجيلزية")
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("ImporeterCompanyAddress_EN");
            entity.Property(e => e.ImportCompanyNameAr)
                .HasComment("أسم الشركة المستوردة باللغه العربية")
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("ImportCompany_Name_AR");
            entity.Property(e => e.ImportCompanyNameEn)
                .HasComment("أسم الشركة المستوردة باللغه الأنجيلزية")
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("ImportCompany_Name_EN");
            entity.Property(e => e.ImporterId)
                .HasComment("رقم الشركة")
                .HasColumnName("Importer_Id");
            entity.Property(e => e.ImportingCountry)
                .HasComment("الدولة المستوردة")
                .HasColumnName("Importing_Country");
            entity.Property(e => e.InternationalTransportationId)
                .HasComment("وسـائل النقل الدولية")
                .HasColumnName("InternationalTransportation_ID");
            entity.Property(e => e.IsAdditionalDeclaretion).HasColumnName("IS_Additional_Declaretion");
            entity.Property(e => e.IsContainers)
                .HasComment("حاويات")
                .HasColumnName("IS_Containers");
            entity.Property(e => e.IsLot)
                .HasComment("لوط")
                .HasColumnName("IS_Lot");
            entity.Property(e => e.IsTreatment)
                .HasComment("معالجه")
                .HasColumnName("IS_Treatment");
            entity.Property(e => e.Isaccepted)
                .HasDefaultValue(false)
                .HasColumnName("ISAccepted");
            entity.Property(e => e.Isenglish)
                .HasComment("لغة الشهادة")
                .HasColumnName("ISEnglish");
            entity.Property(e => e.Isprint).HasColumnName("ISPrint");
            entity.Property(e => e.PortAccess)
                .HasComment("ميناء الوصول")
                .HasColumnName("Port_Access");
            entity.Property(e => e.PortTypeImportingCountry)
                .HasComment("نوع الميناء الدوله المستورده")
                .HasColumnName("Port_Type_Importing_Country");
            entity.Property(e => e.PortTypeTransitCountry)
                .HasComment("نوع الميناء دوله العبور")
                .HasColumnName("Port_Type_Transit_Country");
            entity.Property(e => e.ShipName)
                .HasMaxLength(50)
                .HasComment("تفاصيل أو رقم الرحلة")
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("Ship_Name");
            entity.Property(e => e.ShipmentmeanId)
                .HasComment(" وسيلة الشحن")
                .HasColumnName("ShipmentmeanID");
            entity.Property(e => e.ShippingPolicyNumber).HasComment("رقم بوليصة الشحن");
            entity.Property(e => e.ShippingPort)
                .HasComment("ميناء الشحن")
                .HasColumnName("Shipping_Port");
            entity.Property(e => e.TransitCountry)
                .HasComment("دولة العبور")
                .HasColumnName("Transit_Country");
            entity.Property(e => e.TransitPort)
                .HasComment("ميناء العبور")
                .HasColumnName("Transit_Port");
            entity.Property(e => e.TransportMeanId)
                .HasComment("طــريقة النقل")
                .HasColumnName("Transport_Mean_Id");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ExCheckRequest).WithMany(p => p.ExCertificatesRequests)
                .HasForeignKey(d => d.ExCheckRequestId)
                .HasConstraintName("FK_PlantCertificatesRequests_Ex_CheckRequest");
        });

        modelBuilder.Entity<ExCertificatesRequestsFile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PlantCertificatesRequestsFiles");

            entity.ToTable("Ex_CertificatesRequestsFiles", tb => tb.HasComment("المرفقات الخاصة بالشهادة"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AAttachmentTableTypeId).HasColumnName("A_AttachmentTableTypeID");
            entity.Property(e => e.PlantCertificatesRequestsId).HasColumnName("PlantCertificatesRequestsID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.AAttachmentTableType).WithMany(p => p.ExCertificatesRequestsFiles)
                .HasForeignKey(d => d.AAttachmentTableTypeId)
                .HasConstraintName("FK_PlantCertificatesRequestsFiles_A_AttachmentTableType");

            entity.HasOne(d => d.PlantCertificatesRequests).WithMany(p => p.ExCertificatesRequestsFiles)
                .HasForeignKey(d => d.PlantCertificatesRequestsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlantCertificatesRequestsFiles_PlantCertificatesRequests");
        });

        modelBuilder.Entity<ExCertificatesRequestsLotDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PlantCertificatesRequestsLotData");

            entity.ToTable("Ex_CertificatesRequestsLotData", tb => tb.HasComment("بيانات اللوطات"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ExCheckRequsetShippingMethodId).HasColumnName("Ex_CheckRequset_Shipping_MethodID");
            entity.Property(e => e.Isaccepted).HasColumnName("ISAccepted");
            entity.Property(e => e.ItemShortNameId).HasColumnName("Item_ShortName_ID");
            entity.Property(e => e.LotId).HasColumnName("LotID");
            entity.Property(e => e.PlantCertificatesRequestsId).HasColumnName("PlantCertificatesRequestsID");

            entity.HasOne(d => d.ExCheckRequsetShippingMethod).WithMany(p => p.ExCertificatesRequestsLotData)
                .HasForeignKey(d => d.ExCheckRequsetShippingMethodId)
                .HasConstraintName("FK_Ex_CertificatesRequestsLotData_Ex_CheckRequset_Shipping_Method2");

            entity.HasOne(d => d.PlantCertificatesRequests).WithMany(p => p.ExCertificatesRequestsLotData)
                .HasForeignKey(d => d.PlantCertificatesRequestsId)
                .HasConstraintName("FK_PlantCertificatesRequestsLotData_PlantCertificatesRequests");
        });

        modelBuilder.Entity<ExCertificatesRequestsPayment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PlantCertificatesRequestsPayments");

            entity.ToTable("Ex_CertificatesRequestsPayments", tb => tb.HasComment("تحصيل الرسوم الخاصه بالشهاده"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ExCertificatesRequestsPaymentsType).HasColumnName("Ex_CertificatesRequestsPaymentsType");
            entity.Property(e => e.PlantCertificatesRequestsId).HasColumnName("PlantCertificatesRequestsID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");

            entity.HasOne(d => d.ExCertificatesRequestsPaymentsTypeNavigation).WithMany(p => p.ExCertificatesRequestsPayments)
                .HasForeignKey(d => d.ExCertificatesRequestsPaymentsType)
                .HasConstraintName("FK_Ex_CertificatesRequestsPayments_Ex_CertificatesRequestsPaymentsType");

            entity.HasOne(d => d.PlantCertificatesRequests).WithMany(p => p.ExCertificatesRequestsPayments)
                .HasForeignKey(d => d.PlantCertificatesRequestsId)
                .HasConstraintName("FK_PlantCertificatesRequestsPayments_PlantCertificatesRequests");
        });

        modelBuilder.Entity<ExCertificatesRequestsPaymentsDetaile>(entity =>
        {
            entity.ToTable("Ex_CertificatesRequestsPaymentsDetailes");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CodeBank)
                .HasMaxLength(50)
                .HasComment("كود العملية من البنك")
                .HasColumnName("Code_Bank");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.ExCertificatesRequestsPaymentsId).HasColumnName("Ex_CertificatesRequestsPaymentsID");
            entity.Property(e => e.IsSuccessBank)
                .HasComment("0 تم رفض عملية البنك\r\n1 تم قبول العملية \r\nnull تم الارسال ولم الرد من البنك")
                .HasColumnName("IsSuccess_Bank");
            entity.Property(e => e.OrderNumber).HasMaxLength(14);
            entity.Property(e => e.PaymentTypeId)
                .HasComment("from systemcode table 30\r\nنوع عملية الدفع فيزا - كاش")
                .HasColumnName("Payment_Type_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserTypeId)
                .HasComment("from systemcode table 3\r\nنوع الموظف حجر ولا شركة ولا فرد ولاهيئه")
                .HasColumnName("User_Type_ID");

            entity.HasOne(d => d.ExCertificatesRequestsPayments).WithMany(p => p.ExCertificatesRequestsPaymentsDetailes)
                .HasForeignKey(d => d.ExCertificatesRequestsPaymentsId)
                .HasConstraintName("FK_Ex_CertificatesRequestsPaymentsDetailes_Ex_CertificatesRequestsPayments");
        });

        modelBuilder.Entity<ExCertificatesRequestsPaymentsType>(entity =>
        {
            entity.ToTable("Ex_CertificatesRequestsPaymentsType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<ExCheckRequest>(entity =>
        {
            entity.ToTable("Ex_CheckRequest");

            entity.HasIndex(e => e.CheckRequestNumber, "UQ_EX_CheckRequest_Number").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.CheckRequestNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CheckRequest_Number");
            entity.Property(e => e.ExOpertaionTypeId).HasColumnName("Ex_OpertaionType_ID");
            entity.Property(e => e.ExportCompany).HasMaxLength(250);
            entity.Property(e => e.IsAcceptedDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("IsAccepted_Date");
            entity.Property(e => e.IsPaid).HasDefaultValue(false);
            entity.Property(e => e.NationalIdcompanyOwner)
                .HasMaxLength(14)
                .HasColumnName("NationalIDCompanyOwner");
            entity.Property(e => e.NotesReject)
                .HasComment("اسباب الرفض")
                .HasColumnName("Notes_Reject");
            entity.Property(e => e.OutletId).HasColumnName("Outlet_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserTypeId)
                .HasComment("from A_SystemCode =3")
                .HasColumnName("User_Type_ID");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.Outlet).WithMany(p => p.ExCheckRequests)
                .HasForeignKey(d => d.OutletId)
                .HasConstraintName("FK_Ex_CheckRequest_Outlet");
        });

        modelBuilder.Entity<ExCheckRequestCustomsMessage>(entity =>
        {
            entity.ToTable("Ex_CheckRequest_Customs_Message");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ArrivalDate).HasColumnName("Arrival_Date");
            entity.Property(e => e.CertificateNumberEachProduct)
                .HasMaxLength(50)
                .HasColumnName("Certificate_Number_Each_Product");
            entity.Property(e => e.CertificationDate).HasColumnName("Certification_Date");
            entity.Property(e => e.CustomsCertificateNumber)
                .HasMaxLength(50)
                .HasColumnName("Customs_Certificate_Number");
            entity.Property(e => e.ExCertificatesRequestsId).HasColumnName("Ex_CertificatesRequests_ID");
            entity.Property(e => e.ExCheckRequestId).HasColumnName("Ex_CheckRequest_ID");
            entity.Property(e => e.ImOperationType).HasColumnName("Im_OperationType");
            entity.Property(e => e.ManifestNumber)
                .HasMaxLength(50)
                .HasColumnName("Manifest_Number");
            entity.Property(e => e.ShipmentDate).HasColumnName("Shipment_Date");
            entity.Property(e => e.ShippingAgencyId).HasColumnName("Shipping_Agency_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ExCertificatesRequests).WithMany(p => p.ExCheckRequestCustomsMessages)
                .HasForeignKey(d => d.ExCertificatesRequestsId)
                .HasConstraintName("FK_Ex_CheckRequest_Customs_Message_Ex_CertificatesRequests");

            entity.HasOne(d => d.ExCheckRequest).WithMany(p => p.ExCheckRequestCustomsMessages)
                .HasForeignKey(d => d.ExCheckRequestId)
                .HasConstraintName("FK_Ex_CheckRequest_Customs_Message_Ex_CheckRequest1");

            entity.HasOne(d => d.ShippingAgency).WithMany(p => p.ExCheckRequestCustomsMessages)
                .HasForeignKey(d => d.ShippingAgencyId)
                .HasConstraintName("FK_Ex_CheckRequest_Customs_Message_ShippingAgencies");
        });

        modelBuilder.Entity<ExCheckRequestDataExtra>(entity =>
        {
            entity.ToTable("Ex_CheckRequestData_Extra");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ExCheckRequestDataId).HasColumnName("Ex_CheckRequest_Data_ID");
            entity.Property(e => e.ImporeterCompanyAddress).HasMaxLength(100);
            entity.Property(e => e.ImporeterCompanyAddressEn)
                .HasMaxLength(100)
                .HasColumnName("ImporeterCompanyAddress_EN");
            entity.Property(e => e.ImportCompany).HasMaxLength(50);
            entity.Property(e => e.ImportCompanyEn)
                .HasMaxLength(50)
                .HasColumnName("ImportCompany_EN");
            entity.Property(e => e.OwnerAddress).HasMaxLength(100);
            entity.Property(e => e.OwnerName).HasMaxLength(50);
            entity.Property(e => e.RecieverName)
                .HasMaxLength(100)
                .HasColumnName("Reciever_Name");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ExCheckRequestData).WithMany(p => p.ExCheckRequestDataExtras)
                .HasForeignKey(d => d.ExCheckRequestDataId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ex_CheckRequestData_Extra_Ex_CheckRequest_Data1");
        });

        modelBuilder.Entity<ExCheckRequestDatum>(entity =>
        {
            entity.ToTable("Ex_CheckRequest_Data");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.DelegateAddress)
                .HasMaxLength(100)
                .HasComment("عنوان مندوب صاحب الرسالة");
            entity.Property(e => e.DelegateName)
                .HasMaxLength(50)
                .HasComment("مندوب صاحب الرسالة");
            entity.Property(e => e.ExCheckRequestId).HasColumnName("Ex_CheckRequest_ID");
            entity.Property(e => e.ExportCountryId).HasColumnName("ExportCountry_Id");
            entity.Property(e => e.ExportRegionsId).HasColumnName("Export_Regions_ID");
            entity.Property(e => e.GovernateId).HasColumnName("Governate_ID");
            entity.Property(e => e.ImporterId).HasColumnName("Importer_ID");
            entity.Property(e => e.ImporterTypeId).HasColumnName("ImporterType_Id");
            entity.Property(e => e.InternationalTransportationId).HasColumnName("InternationalTransportation_ID");
            entity.Property(e => e.NationalIdcompanyOwner)
                .HasMaxLength(14)
                .HasComment("الرقم القومي لمندوب صاحب الرسالة")
                .HasColumnName("NationalIDCompanyOwner");
            entity.Property(e => e.ShipName)
                .HasMaxLength(50)
                .HasColumnName("Ship_Name");
            entity.Property(e => e.ShipmentMeanId).HasColumnName("Shipment_Mean_Id");
            entity.Property(e => e.ShippingCompaniesId).HasColumnName("ShippingCompanies_ID");
            entity.Property(e => e.TransitCountryId).HasColumnName("TransitCountry_Id");
            entity.Property(e => e.TransitRegionsId).HasColumnName("Transit_Regions_ID");
            entity.Property(e => e.TransportMeanId).HasColumnName("Transport_Mean_Id");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ExCheckRequest).WithMany(p => p.ExCheckRequestData)
                .HasForeignKey(d => d.ExCheckRequestId)
                .HasConstraintName("FK_Ex_CheckRequest_Data_Ex_CheckRequest1");

            entity.HasOne(d => d.ExportCountry).WithMany(p => p.ExCheckRequestData)
                .HasForeignKey(d => d.ExportCountryId)
                .HasConstraintName("FK_Ex_CheckRequest_Data_Country");

            entity.HasOne(d => d.InternationalTransportation).WithMany(p => p.ExCheckRequestData)
                .HasForeignKey(d => d.InternationalTransportationId)
                .HasConstraintName("FK_Ex_CheckRequest_Data_InternationalTransportation");

            entity.HasOne(d => d.ShipmentMean).WithMany(p => p.ExCheckRequestData)
                .HasForeignKey(d => d.ShipmentMeanId)
                .HasConstraintName("FK_Ex_CheckRequest_Data_Shipment_Mean");

            entity.HasOne(d => d.ShippingCompanies).WithMany(p => p.ExCheckRequestData)
                .HasForeignKey(d => d.ShippingCompaniesId)
                .HasConstraintName("FK_Ex_CheckRequest_Data_ShippingCompanies");

            entity.HasOne(d => d.TransportMean).WithMany(p => p.ExCheckRequestData)
                .HasForeignKey(d => d.TransportMeanId)
                .HasConstraintName("FK_Ex_CheckRequest_Data_Transport_Mean");
        });

        modelBuilder.Entity<ExCheckRequestFee>(entity =>
        {
            entity.ToTable("Ex_CheckRequest_Fees");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ExCheckRequestId).HasColumnName("Ex_CheckRequest_ID");
            entity.Property(e => e.FeeValue)
                .HasComment("قيمة الرسوم")
                .HasColumnType("money")
                .HasColumnName("Fee_Value");
            entity.Property(e => e.IsFeeRounding)
                .HasComment("تقريب الرسوم")
                .HasColumnName("is_Fee_Rounding");
            entity.Property(e => e.TotalAmount)
                .HasComment("اجمالى الرسوم")
                .HasColumnType("money")
                .HasColumnName("Total_Amount");
            entity.Property(e => e.TotalGrossWeight)
                .HasComment("الوزن الاجمالى للطلب")
                .HasColumnType("decimal(22, 6)")
                .HasColumnName("Total_GrossWeight");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");

            entity.HasOne(d => d.ExCheckRequest).WithMany(p => p.ExCheckRequestFees)
                .HasForeignKey(d => d.ExCheckRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ex_CheckRequest_Fees_Ex_CheckRequest");
        });

        modelBuilder.Entity<ExCheckRequestFinalResult>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Ex_CheckRequest_Items_Final_Position");

            entity.ToTable("Ex_CheckRequest_Final_Result");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ExCheckRequestId).HasColumnName("Ex_CheckRequest_ID");
            entity.Property(e => e.ExFinalResultId).HasColumnName("Ex_Final_Result_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ExCheckRequest).WithMany(p => p.ExCheckRequestFinalResults)
                .HasForeignKey(d => d.ExCheckRequestId)
                .HasConstraintName("FK_Ex_CheckRequest_Items_Final_Result_Ex_CheckRequest");

            entity.HasOne(d => d.ExFinalResult).WithMany(p => p.ExCheckRequestFinalResults)
                .HasForeignKey(d => d.ExFinalResultId)
                .HasConstraintName("FK_Ex_CheckRequest_Items_Final_Position_Ex_Final_Position");
        });

        modelBuilder.Entity<ExCheckRequestItem>(entity =>
        {
            entity.ToTable("Ex_CheckRequest_Items");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AcceptDate).HasColumnName("Accept_Date");
            entity.Property(e => e.AcceptUserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Accept_User_Creation_Date");
            entity.Property(e => e.AcceptUserCreationId).HasColumnName("Accept_User_Creation_Id");
            entity.Property(e => e.AcceptUserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Accept_User_Updation_Date");
            entity.Property(e => e.AcceptUserUpdationId).HasColumnName("Accept_User_Updation_Id");
            entity.Property(e => e.AgricultureHand)
                .HasMaxLength(250)
                .HasComment("ناحية الزراعة")
                .HasColumnName("Agriculture_Hand");
            entity.Property(e => e.CenterId).HasColumnName("Center_ID");
            entity.Property(e => e.CountryId).HasColumnName("Country_ID");
            entity.Property(e => e.ExCheckRequestId).HasColumnName("Ex_CheckRequest_ID");
            entity.Property(e => e.FarmsDataId).HasColumnName("FarmsData_ID");
            entity.Property(e => e.Fees).HasColumnType("money");
            entity.Property(e => e.GovernateId).HasColumnName("Governate_ID");
            entity.Property(e => e.GrossWeight).HasColumnType("decimal(22, 6)");
            entity.Property(e => e.IsLotDivision).HasColumnName("Is_LotDivision");
            entity.Property(e => e.ItemCategoriesGroupId).HasColumnName("ItemCategories_Group_ID");
            entity.Property(e => e.ItemCategoryId).HasColumnName("ItemCategory_ID");
            entity.Property(e => e.ItemPermissionNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("Item_Permission_Number");
            entity.Property(e => e.ItemShortNameId).HasColumnName("Item_ShortName_ID");
            entity.Property(e => e.NetWeight)
                .HasColumnType("decimal(22, 6)")
                .HasColumnName("Net_Weight");
            entity.Property(e => e.NetWeightOld)
                .HasColumnType("decimal(22, 6)")
                .HasColumnName("Net_WeightOld");
            entity.Property(e => e.OrderText).HasColumnName("Order_Text");
            entity.Property(e => e.PackageCount).HasColumnName("Package_Count");
            entity.Property(e => e.PackageMaterialId).HasColumnName("Package_Material_ID");
            entity.Property(e => e.PackageTypeId).HasColumnName("Package_Type_ID");
            entity.Property(e => e.PackageWeight)
                .HasColumnType("decimal(22, 6)")
                .HasColumnName("Package_Weight");
            entity.Property(e => e.SubPartId).HasColumnName("SubPart_id");
            entity.Property(e => e.UnitsNumber).HasColumnName("Units_Number");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.VillageId).HasColumnName("Village_ID");

            entity.HasOne(d => d.Center).WithMany(p => p.ExCheckRequestItems)
                .HasForeignKey(d => d.CenterId)
                .HasConstraintName("FK_Ex_CheckRequest_Items_Center");

            entity.HasOne(d => d.ExCheckRequest).WithMany(p => p.ExCheckRequestItems)
                .HasForeignKey(d => d.ExCheckRequestId)
                .HasConstraintName("FK_Ex_CheckRequest_Items_Ex_CheckRequest");

            entity.HasOne(d => d.FarmsData).WithMany(p => p.ExCheckRequestItems)
                .HasForeignKey(d => d.FarmsDataId)
                .HasConstraintName("FK_Ex_CheckRequest_Items_FarmsData");

            entity.HasOne(d => d.Governate).WithMany(p => p.ExCheckRequestItems)
                .HasForeignKey(d => d.GovernateId)
                .HasConstraintName("FK_Ex_CheckRequest_Items_Governate");

            entity.HasOne(d => d.ItemCategoriesGroup).WithMany(p => p.ExCheckRequestItems)
                .HasForeignKey(d => d.ItemCategoriesGroupId)
                .HasConstraintName("FK_Ex_CheckRequest_Items_ItemCategories_Group");

            entity.HasOne(d => d.ItemCategory).WithMany(p => p.ExCheckRequestItems)
                .HasForeignKey(d => d.ItemCategoryId)
                .HasConstraintName("FK_Ex_CheckRequest_Items_ItemCategories");

            entity.HasOne(d => d.ItemShortName).WithMany(p => p.ExCheckRequestItems)
                .HasForeignKey(d => d.ItemShortNameId)
                .HasConstraintName("FK_Ex_CheckRequest_Items_Item_ShortName");

            entity.HasOne(d => d.Village).WithMany(p => p.ExCheckRequestItems)
                .HasForeignKey(d => d.VillageId)
                .HasConstraintName("FK_Ex_CheckRequest_Items_Village");
        });

        modelBuilder.Entity<ExCheckRequestItemsLotCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Ex_CheckRequest_Items_Category");

            entity.ToTable("Ex_CheckRequest_Items_Lot_Category");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.BasedWeight)
                .HasComment("مش مستخدم")
                .HasColumnType("decimal(22, 6)")
                .HasColumnName("Based_Weight");
            entity.Property(e => e.ExCheckRequestItemsId).HasColumnName("Ex_CheckRequest_Items_ID");
            entity.Property(e => e.ExCheckRequsetShippingMethodId).HasColumnName("Ex_CheckRequset_Shipping_MethodID");
            entity.Property(e => e.FarmsCode).HasMaxLength(300);
            entity.Property(e => e.FarmsDataId).HasColumnName("FarmsData_ID");
            entity.Property(e => e.GrossWeight)
                .HasComment("اجمالى الوزن القائم لللوطات")
                .HasColumnType("decimal(22, 6)");
            entity.Property(e => e.GrossWeightOld).HasColumnType("decimal(22, 6)");
            entity.Property(e => e.GrowerNumber)
                .HasMaxLength(50)
                .HasColumnName("Grower_Number");
            entity.Property(e => e.LotNumber)
                .HasMaxLength(50)
                .HasColumnName("Lot_Number");
            entity.Property(e => e.NetWeight)
                .HasComment("الوزن الصافي لللوطات")
                .HasColumnType("decimal(22, 6)")
                .HasColumnName("Net_Weight");
            entity.Property(e => e.NumberWoodenPackage)
                .HasMaxLength(50)
                .HasColumnName("Number_Wooden_Package");
            entity.Property(e => e.OrderText).HasColumnName("Order_Text");
            entity.Property(e => e.PackageBasedWeight)
                .HasComment("وزن العبوة القائم")
                .HasColumnType("decimal(22, 6)")
                .HasColumnName("Package_Based_Weight");
            entity.Property(e => e.PackageCount)
                .HasComment("عدد العبوات")
                .HasColumnName("Package_Count");
            entity.Property(e => e.PackageMaterialId).HasColumnName("Package_Material_ID");
            entity.Property(e => e.PackageNetWeight)
                .HasComment("وزن العبوة الصافي")
                .HasColumnType("decimal(22, 6)")
                .HasColumnName("Package_Net_Weight");
            entity.Property(e => e.PackageTypeId).HasColumnName("Package_Type_ID");
            entity.Property(e => e.PackageWeight)
                .HasComment("الوزن العبوه الفارغ")
                .HasColumnType("decimal(22, 6)")
                .HasColumnName("Package_Weight");
            entity.Property(e => e.ReasonEntry).HasColumnName("Reason_Entry");
            entity.Property(e => e.RejectReason).HasMaxLength(300);
            entity.Property(e => e.UnitsNumber).HasColumnName("Units_Number");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
            entity.Property(e => e.Waybill).HasMaxLength(100);

            entity.HasOne(d => d.ExCheckRequestItems).WithMany(p => p.ExCheckRequestItemsLotCategories)
                .HasForeignKey(d => d.ExCheckRequestItemsId)
                .HasConstraintName("FK_Ex_CheckRequest_Items_Category_Ex_CheckRequest_Items");

            entity.HasOne(d => d.ExCheckRequsetShippingMethod).WithMany(p => p.ExCheckRequestItemsLotCategories)
                .HasForeignKey(d => d.ExCheckRequsetShippingMethodId)
                .HasConstraintName("FK_Ex_CheckRequest_Items_Lot_Category_Ex_CheckRequset_Shipping_Method");
        });

        modelBuilder.Entity<ExCheckRequestItemsLotResult>(entity =>
        {
            entity.ToTable("Ex_CheckRequest_Items_Lot_Result");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ExCheckRequestItemsLotCategoryId).HasColumnName("Ex_CheckRequest_Items_Lot_Category_ID");
            entity.Property(e => e.IsStatus).HasColumnName("IS_Status");
            entity.Property(e => e.IsStatusCommittee)
                .HasComment("الموقف مقبول او مرفوض")
                .HasColumnName("IS_Status_Committee");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ExCheckRequestItemsLotCategory).WithMany(p => p.ExCheckRequestItemsLotResults)
                .HasForeignKey(d => d.ExCheckRequestItemsLotCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ex_CheckRequest_Items_Lot_Result_Ex_CheckRequest_Items_Lot_Category");

            entity.HasOne(d => d.IsStatusNavigation).WithMany(p => p.ExCheckRequestItemsLotResults)
                .HasForeignKey(d => d.IsStatus)
                .HasConstraintName("FK_Ex_CheckRequest_Items_Lot_Result_Ex_CheckRequest_Lot_Result_Status");
        });

        modelBuilder.Entity<ExCheckRequestLotResultStatus>(entity =>
        {
            entity.ToTable("Ex_CheckRequest_Lot_Result_Status");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CommitteeTypeId).HasColumnName("CommitteeType_ID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsContinue)
                .HasComment("0 عدم استكمال الاعمال\r\nلا يمكن استكمال الاعمال 1")
                .HasColumnName("Is_Continue");
            entity.Property(e => e.NameAr).HasColumnName("Name_AR");
            entity.Property(e => e.NameEn).HasColumnName("Name_En");
        });

        modelBuilder.Entity<ExCheckRequestOrganizationDistribution>(entity =>
        {
            entity.ToTable("Ex_CheckRequest_Organization_Distribution");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ExCheckRequestId).HasColumnName("Ex_CheckRequest_ID");
            entity.Property(e => e.OrganizationId)
                .HasComment("رقم الجهة")
                .HasColumnName("Organization_ID");
            entity.Property(e => e.OrganizationTypeId)
                .HasComment("نوع الجهة")
                .HasColumnName("Organization_Type_Id");
            entity.Property(e => e.QuantityTon)
                .HasComment("الكمية الصالحة للتصدير")
                .HasColumnName("Quantity_Ton");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ExCheckRequest).WithMany(p => p.ExCheckRequestOrganizationDistributions)
                .HasForeignKey(d => d.ExCheckRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ex_CheckRequest_Organization_Distribution_Ex_CheckRequest");
        });

        modelBuilder.Entity<ExCheckRequestOrganizationDistributionDetial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Im_CheckRequest_Organization_Distribution_Detials");

            entity.ToTable("Ex_CheckRequest_Organization_Distribution_Detials");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.ExCheckRequestId).HasColumnName("Ex_CheckRequest_ID");
            entity.Property(e => e.ExCheckRequestOrganizationDistributionMasterId).HasColumnName("Ex_CheckRequest_Organization_Distribution_Master_ID");
            entity.Property(e => e.QuantityTon)
                .HasComment("الكمية الصالحة للتصدير")
                .HasColumnName("Quantity_Ton");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ExCheckRequest).WithMany(p => p.ExCheckRequestOrganizationDistributionDetials)
                .HasForeignKey(d => d.ExCheckRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ex_CheckRequest_Organization_Distribution_Detials_Ex_CheckRequest");

            entity.HasOne(d => d.ExCheckRequestOrganizationDistributionMaster).WithMany(p => p.ExCheckRequestOrganizationDistributionDetials)
                .HasForeignKey(d => d.ExCheckRequestOrganizationDistributionMasterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ex_CheckRequest_Distribution_Im_CheckRequest_Organization_Distribution");
        });

        modelBuilder.Entity<ExCheckRequestOrganizationDistributionMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Im_CheckRequest_Organization");

            entity.ToTable("Ex_CheckRequest_Organization_Distribution_Master");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ItemId).HasColumnName("Item_ID");
            entity.Property(e => e.ItemShortNameId).HasColumnName("Item_ShortName_ID");
            entity.Property(e => e.OrganizationId)
                .HasComment("رقم الجهة")
                .HasColumnName("Organization_ID");
            entity.Property(e => e.OrganizationTypeId)
                .HasComment("نوع الجهة")
                .HasColumnName("Organization_Type_Id");
            entity.Property(e => e.RegisteredQuantityTonExCheckRequest).HasColumnName("Registered_Quantity_Ton_Ex_CheckRequest");
            entity.Property(e => e.TotallQuantityTonExCheckRequest)
                .HasComment("الكمية الصالحة للتصدير")
                .HasColumnName("Totall_Quantity_Ton_Ex_CheckRequest");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ItemShortName).WithMany(p => p.ExCheckRequestOrganizationDistributionMasters)
                .HasForeignKey(d => d.ItemShortNameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ex_CheckRequest_Organization_Distribution_Item_ShortName");
        });

        modelBuilder.Entity<ExCheckRequestPlace>(entity =>
        {
            entity.ToTable("Ex_CheckRequest_Places");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CenterId)
                .HasComment("المركز")
                .HasColumnName("Center_ID");
            entity.Property(e => e.ExCheckRequestId).HasColumnName("Ex_CheckRequest_ID");
            entity.Property(e => e.ExaminationLocation)
                .HasMaxLength(250)
                .HasComment("مكان الفحص")
                .HasColumnName("Examination_location");
            entity.Property(e => e.GovernId)
                .HasComment("المحافظة")
                .HasColumnName("Govern_ID");
            entity.Property(e => e.OutletExmainiationId).HasColumnName("Outlet_Exmainiation_ID");
            entity.Property(e => e.OutletGenshiId).HasColumnName("Outlet_Genshi_ID");
            entity.Property(e => e.PortNationalId)
                .HasComment(" الميناء للجشني")
                .HasColumnName("PortNational_ID");
            entity.Property(e => e.StationAccreditationDataExaminationId)
                .HasComment("مسمسي الاعتماد للمحطة")
                .HasColumnName("Station_Accreditation_Data_Examination_ID");
            entity.Property(e => e.StationExaminationId)
                .HasComment("محطة الفحص")
                .HasColumnName("Station_Examination_ID");
            entity.Property(e => e.StationGenshiId)
                .HasComment("محطة الجشني")
                .HasColumnName("Station_Genshi_ID");

            entity.HasOne(d => d.Center).WithMany(p => p.ExCheckRequestPlaces)
                .HasForeignKey(d => d.CenterId)
                .HasConstraintName("FK_Ex_CheckRequest_Places_Center");

            entity.HasOne(d => d.ExCheckRequest).WithMany(p => p.ExCheckRequestPlaces)
                .HasForeignKey(d => d.ExCheckRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ex_CheckRequest_Places_Ex_CheckRequest");

            entity.HasOne(d => d.Govern).WithMany(p => p.ExCheckRequestPlaces)
                .HasForeignKey(d => d.GovernId)
                .HasConstraintName("FK_Ex_CheckRequest_Places_Governate");

            entity.HasOne(d => d.PortNational).WithMany(p => p.ExCheckRequestPlaces)
                .HasForeignKey(d => d.PortNationalId)
                .HasConstraintName("FK_Ex_CheckRequest_Places_PortNational");

            entity.HasOne(d => d.StationExamination).WithMany(p => p.ExCheckRequestPlaceStationExaminations)
                .HasForeignKey(d => d.StationExaminationId)
                .HasConstraintName("FK_Ex_CheckRequest_Places_Station3");

            entity.HasOne(d => d.StationGenshi).WithMany(p => p.ExCheckRequestPlaceStationGenshis)
                .HasForeignKey(d => d.StationGenshiId)
                .HasConstraintName("FK_Ex_CheckRequest_Places_Station2");
        });

        modelBuilder.Entity<ExCheckRequestPort>(entity =>
        {
            entity.ToTable("Ex_CheckRequest_Port");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ExCheckRequestDataId).HasColumnName("Ex_CheckRequest_Data_ID");
            entity.Property(e => e.PortId).HasColumnName("Port_ID");
            entity.Property(e => e.PortTypeId).HasColumnName("Port_Type_ID");
            entity.Property(e => e.ReqPortTypeId).HasColumnName("ReqPortType_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ExCheckRequestData).WithMany(p => p.ExCheckRequestPorts)
                .HasForeignKey(d => d.ExCheckRequestDataId)
                .HasConstraintName("FK_Ex_CheckRequest_Port_Ex_CheckRequest_Data1");
        });

        modelBuilder.Entity<ExCheckRequestRefuseReason>(entity =>
        {
            entity.ToTable("Ex_CheckRequest_RefuseReason");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ExCheckRequestId).HasColumnName("Ex_CheckRequest_Id");
            entity.Property(e => e.RefuseReasonId).HasColumnName("Refuse_Reason_Id");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");

            entity.HasOne(d => d.ExCheckRequest).WithMany(p => p.ExCheckRequestRefuseReasons)
                .HasForeignKey(d => d.ExCheckRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ex_CheckRequest_RefuseReason_Ex_CheckRequest");

            entity.HasOne(d => d.RefuseReason).WithMany(p => p.ExCheckRequestRefuseReasons)
                .HasForeignKey(d => d.RefuseReasonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ex_CheckRequest_RefuseReason_Refuse_Reason");
        });

        modelBuilder.Entity<ExCheckRequestSampleDataConfirm>(entity =>
        {
            entity.ToTable("Ex_CheckRequest_SampleData_Confirm");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnType("smalldatetime");
            entity.Property(e => e.ExCheckRequestSampleDataId).HasColumnName("Ex_CheckRequest_SampleData_ID");
            entity.Property(e => e.IsAccepted).HasDefaultValue(true);
            entity.Property(e => e.Notes).HasMaxLength(500);

            entity.HasOne(d => d.ExCheckRequestSampleData).WithMany(p => p.ExCheckRequestSampleDataConfirms)
                .HasForeignKey(d => d.ExCheckRequestSampleDataId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ex_CheckRequest_SampleData_Confirm_Ex_CheckRequest_SampleData");
        });

        modelBuilder.Entity<ExCheckRequestSampleDatum>(entity =>
        {
            entity.ToTable("Ex_CheckRequest_SampleData");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AdminConfirmation).HasColumnName("Admin_Confirmation");
            entity.Property(e => e.AdminDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Admin_Date");
            entity.Property(e => e.AdminUser).HasColumnName("Admin_User");
            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.AnalysisLabTypeId).HasColumnName("AnalysisLabType_ID");
            entity.Property(e => e.CountSample).HasColumnName("Count_Sample");
            entity.Property(e => e.ExRequestCommitteeId).HasColumnName("Ex_RequestCommittee_ID");
            entity.Property(e => e.ExRequestItemId).HasColumnName("Ex_Request_Item_Id");
            entity.Property(e => e.FeesActual)
                .HasColumnType("money")
                .HasColumnName("Fees_Actual");
            entity.Property(e => e.IsFromAndroid)
                .HasDefaultValue(false)
                .HasColumnName("IS_From_Android");
            entity.Property(e => e.IsTotal).HasColumnName("IS_Total");
            entity.Property(e => e.IsTotalAndroid).HasColumnName("IS_Total_Android");
            entity.Property(e => e.ItemShortNameId).HasColumnName("Item_ShortName_ID");
            entity.Property(e => e.LotDataId).HasColumnName("LotData_ID");
            entity.Property(e => e.NotesAr)
                .HasMaxLength(300)
                .HasColumnName("Notes_Ar");
            entity.Property(e => e.NotesEn)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("Notes_En");
            entity.Property(e => e.RejectReasonAr)
                .HasMaxLength(150)
                .HasColumnName("RejectReason_Ar");
            entity.Property(e => e.RejectReasonEn)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("RejectReason_En");
            entity.Property(e => e.SampleBarCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Sample_BarCode");
            entity.Property(e => e.SylAlkhatimaNumber).HasColumnName("Syl_ALkhatima_Number");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.AnalysisLabType).WithMany(p => p.ExCheckRequestSampleData)
                .HasForeignKey(d => d.AnalysisLabTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ex_CheckRequest_SampleData_AnalysisLabType");

            entity.HasOne(d => d.ExRequestCommittee).WithMany(p => p.ExCheckRequestSampleData)
                .HasForeignKey(d => d.ExRequestCommitteeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ex_CheckRequest_SampleData_Ex_RequestCommittee");
        });

        modelBuilder.Entity<ExCheckRequestVisa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Ex_CheckRequest_Items_Lot_Visa");

            entity.ToTable("Ex_CheckRequest_Visa");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ExCheckRequestId).HasColumnName("Ex_CheckRequest_ID");
            entity.Property(e => e.ExVisaId).HasColumnName("Ex_Visa_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ExCheckRequest).WithMany(p => p.ExCheckRequestVisas)
                .HasForeignKey(d => d.ExCheckRequestId)
                .HasConstraintName("FK_Ex_CheckRequest_Items_Lot_Visa_Ex_CheckRequest");

            entity.HasOne(d => d.ExVisa).WithMany(p => p.ExCheckRequestVisas)
                .HasForeignKey(d => d.ExVisaId)
                .HasConstraintName("FK_Ex_CheckRequest_Visa_Ex_Visa");

            entity.HasOne(d => d.ExVisaNavigation).WithMany(p => p.ExCheckRequestVisas)
                .HasForeignKey(d => d.ExVisaId)
                .HasConstraintName("FK_Ex_CheckRequest_Items_Lot_Visa_Ex_Visa");
        });

        modelBuilder.Entity<ExCheckRequsetShippingMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Ex_CheckRequset_shippingmethod2");

            entity.ToTable("Ex_CheckRequset_Shipping_Method");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ContainerNumber).HasMaxLength(50);
            entity.Property(e => e.ContainersId).HasColumnName("containers_ID");
            entity.Property(e => e.ContainersTypeId).HasColumnName("containers_type_ID");
            entity.Property(e => e.ExCheckRequestId).HasColumnName("Ex_CheckRequest_ID");
            entity.Property(e => e.NavigationalNumber).HasMaxLength(50);
            entity.Property(e => e.ShipholdNumber).HasMaxLength(50);
            entity.Property(e => e.TotalWeight)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Total_Weight");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
        });

        modelBuilder.Entity<ExChooseSampleDatum>(entity =>
        {
            entity.ToTable("EX_Choose_SampleData");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AnalysisLabTypeId).HasColumnName("AnalysisLabType_ID");
            entity.Property(e => e.ExCheckRequestId).HasColumnName("Ex_CheckRequest_ID");
            entity.Property(e => e.ExCountryConstrainAnalysisLabTypeId).HasColumnName("Ex_CountryConstrain_AnalysisLabType_ID");
            entity.Property(e => e.ItemShortNameId).HasColumnName("Item_ShortName_ID");

            entity.HasOne(d => d.AnalysisLabType).WithMany(p => p.ExChooseSampleData)
                .HasForeignKey(d => d.AnalysisLabTypeId)
                .HasConstraintName("FK_EX_Choose_SampleData_AnalysisLabType");

            entity.HasOne(d => d.ExCheckRequest).WithMany(p => p.ExChooseSampleData)
                .HasForeignKey(d => d.ExCheckRequestId)
                .HasConstraintName("FK_EX_Choose_SampleData_Ex_CheckRequest");

            entity.HasOne(d => d.ExCountryConstrainAnalysisLabType).WithMany(p => p.ExChooseSampleData)
                .HasForeignKey(d => d.ExCountryConstrainAnalysisLabTypeId)
                .HasConstraintName("FK_EX_Choose_SampleData_Ex_CountryConstrain_AnalysisLabType");

            entity.HasOne(d => d.ItemShortName).WithMany(p => p.ExChooseSampleData)
                .HasForeignKey(d => d.ItemShortNameId)
                .HasConstraintName("FK_EX_Choose_SampleData_Item_ShortName");
        });

        modelBuilder.Entity<ExChooseTreatment>(entity =>
        {
            entity.ToTable("EX_Choose_Treatment", tb => tb.HasComment("اختيار المعالجه"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ExCheckRequestId).HasColumnName("Ex_CheckRequest_ID");
            entity.Property(e => e.ExCountryConstrainTreatmentId).HasColumnName("Ex_CountryConstrain_Treatment_id");
            entity.Property(e => e.IsOptional)
                .HasComment("التحليل اختيارى =0 \r\nالتحليل اجباري =1")
                .HasColumnName("IS_Optional");
            entity.Property(e => e.ItemShortNameId)
                .HasComment("product or plant ID manual no relation")
                .HasColumnName("Item_ShortName_id");
            entity.Property(e => e.TreatmentMethodsId).HasColumnName("TreatmentMethods_ID");

            entity.HasOne(d => d.ExCheckRequest).WithMany(p => p.ExChooseTreatments)
                .HasForeignKey(d => d.ExCheckRequestId)
                .HasConstraintName("FK_EX_Choose_Treatment_Ex_CheckRequest");

            entity.HasOne(d => d.ExCountryConstrainTreatment).WithMany(p => p.ExChooseTreatments)
                .HasForeignKey(d => d.ExCountryConstrainTreatmentId)
                .HasConstraintName("FK_EX_Choose_Treatment_Ex_CountryConstrain_Treatment");

            entity.HasOne(d => d.TreatmentMethods).WithMany(p => p.ExChooseTreatments)
                .HasForeignKey(d => d.TreatmentMethodsId)
                .HasConstraintName("FK_EX_Choose_Treatment_TreatmentMethods");
        });

        modelBuilder.Entity<ExCommitteeCheckLocation>(entity =>
        {
            entity.ToTable("Ex_CommitteeCheckLocation");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<ExCommitteeResult>(entity =>
        {
            entity.ToTable("Ex_CommitteeResult");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AdminFinalResultNote).HasColumnName("AdminFinalResult_Note");
            entity.Property(e => e.CommitteeId).HasColumnName("Committee_ID");
            entity.Property(e => e.CommitteeResultTypeId).HasColumnName("CommitteeResultType_ID");
            entity.Property(e => e.Date).HasColumnType("smalldatetime");
            entity.Property(e => e.ExRequestItemId).HasColumnName("Ex_Request_Item_Id");
            entity.Property(e => e.IsTotal).HasColumnName("IS_Total");
            entity.Property(e => e.IsTotalAndroid).HasColumnName("IS_Total_Android");
            entity.Property(e => e.ItemShortNameId).HasColumnName("Item_ShortName_ID");
            entity.Property(e => e.LotDataId).HasColumnName("LotData_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.Committee).WithMany(p => p.ExCommitteeResults)
                .HasForeignKey(d => d.CommitteeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ex_CommitteeResult_Ex_RequestCommittee");

            entity.HasOne(d => d.CommitteeResultType).WithMany(p => p.ExCommitteeResults)
                .HasForeignKey(d => d.CommitteeResultTypeId)
                .HasConstraintName("FK_Ex_CommitteeResult_CommitteeResultType");

            entity.HasOne(d => d.ItemShortName).WithMany(p => p.ExCommitteeResults)
                .HasForeignKey(d => d.ItemShortNameId)
                .HasConstraintName("FK_Ex_CommitteeResult_Item_ShortName");
        });

        modelBuilder.Entity<ExCommitteeResultConfirm>(entity =>
        {
            entity.ToTable("Ex_CommitteeResult_Confirm");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnType("smalldatetime");
            entity.Property(e => e.ExCommitteeResultId).HasColumnName("Ex_CommitteeResult_ID");
            entity.Property(e => e.IsAccepted).HasDefaultValue(true);

            entity.HasOne(d => d.ExCommitteeResult).WithMany(p => p.ExCommitteeResultConfirms)
                .HasForeignKey(d => d.ExCommitteeResultId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ex_CommitteeResult_Confirm_Ex_CommitteeResult");
        });

        modelBuilder.Entity<ExCommitteeResultInfection>(entity =>
        {
            entity.ToTable("Ex_CommitteeResult_Infection");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ExCommitteeResultId).HasColumnName("Ex_CommitteeResult_ID");
            entity.Property(e => e.ItemId).HasColumnName("Item_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ExCommitteeResult).WithMany(p => p.ExCommitteeResultInfections)
                .HasForeignKey(d => d.ExCommitteeResultId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ex_CommitteeResult_Infection_Ex_CommitteeResult");

            entity.HasOne(d => d.Item).WithMany(p => p.ExCommitteeResultInfections)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ex_CommitteeResult_Infection_Item");
        });

        modelBuilder.Entity<ExConstrainCountryItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_EX_Constrain_Type");

            entity.ToTable("EX_Constrain_Country_Item", tb => tb.HasComment("انواع الاشتراطات"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ArName)
                .HasMaxLength(150)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Ar_Name");
            entity.Property(e => e.EnName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("En_Name");
            entity.Property(e => e.ExConstrainTypeId).HasColumnName("EX_Constrain_Type_ID");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasComment("مفعل");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ExConstrainType).WithMany(p => p.ExConstrainCountryItems)
                .HasForeignKey(d => d.ExConstrainTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EX_Constrain_Type_EX_Constrain");
        });

        modelBuilder.Entity<ExConstrainText>(entity =>
        {
            entity.ToTable("EX_Constrain_Text");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ConstrainTextAr).HasColumnName("ConstrainText_Ar");
            entity.Property(e => e.ConstrainTextEn)
                .IsUnicode(false)
                .HasColumnName("ConstrainText_En");
            entity.Property(e => e.ExConstrainCountryItemId).HasColumnName("EX_Constrain_Country_Item_ID");
            entity.Property(e => e.InSideCertificateAr).HasColumnName("InSide_Certificate_Ar");
            entity.Property(e => e.InSideCertificateEn)
                .IsUnicode(false)
                .HasColumnName("InSide_Certificate_En");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasComment("");
            entity.Property(e => e.IsCertificateAddtion)
                .HasComment("شهادة الصحة النباتية")
                .HasColumnName("IsCertificate_Addtion");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ExConstrainCountryItem).WithMany(p => p.ExConstrainTexts)
                .HasForeignKey(d => d.ExConstrainCountryItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EX_Constrain_Text_EX_Constrain_Type");
        });

        modelBuilder.Entity<ExConstrainType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_EX_Constrain");

            entity.ToTable("EX_Constrain_Type", tb => tb.HasComment(" الاشتراطات"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ArName)
                .HasMaxLength(150)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Ar_Name");
            entity.Property(e => e.EnName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("En_Name");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasComment("مفعل");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<ExConstran>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Ex_Constran");

            entity.Property(e => e.ArName)
                .HasMaxLength(150)
                .HasColumnName("Ar_Name");
            entity.Property(e => e.ConstrainTextAr).HasColumnName("ConstrainText_Ar");
            entity.Property(e => e.ConstrainTextEn)
                .IsUnicode(false)
                .HasColumnName("ConstrainText_En");
            entity.Property(e => e.EnName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("En_Name");
            entity.Property(e => e.Expr1).HasMaxLength(150);
            entity.Property(e => e.Expr2)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ImportCountryId).HasColumnName("Import_Country_ID");
            entity.Property(e => e.InSideCertificateAr).HasColumnName("InSide_Certificate_Ar");
            entity.Property(e => e.InSideCertificateEn)
                .IsUnicode(false)
                .HasColumnName("InSide_Certificate_En");
            entity.Property(e => e.IsCertificateAddtion).HasColumnName("IsCertificate_Addtion");
            entity.Property(e => e.ItemCategoriesId).HasColumnName("ItemCategories_ID");
            entity.Property(e => e.ItemShortNameId).HasColumnName("Item_ShortName_id");
            entity.Property(e => e.ShortNameAr).HasColumnName("ShortName_Ar");
            entity.Property(e => e.ShortNameEn)
                .IsUnicode(false)
                .HasColumnName("ShortName_En");
            entity.Property(e => e.TransportCountryId).HasColumnName("TransportCountry_ID");
        });

        modelBuilder.Entity<ExContactDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Company_ContactType");

            entity.ToTable("Ex_ContactData", tb => tb.HasComment("وسائل اتصال المصدر"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ContactTypeId)
                .HasComment("نوع وسيلة الاتصال")
                .HasColumnName("ContactType_ID");
            entity.Property(e => e.ExporterId)
                .HasComment("المصدر(شركة أو هيئه عامة)")
                .HasColumnName("Exporter_ID");
            entity.Property(e => e.ExporterTypeId)
                .HasComment("0 if National company/ 1 if Public Organization")
                .HasColumnName("ExporterType_Id");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
            entity.Property(e => e.Value)
                .HasMaxLength(150)
                .HasComment("الرقم");

            entity.HasOne(d => d.ContactType).WithMany(p => p.ExContactData)
                .HasForeignKey(d => d.ContactTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Company_ContactType_ContactType");

            entity.HasOne(d => d.ExporterType).WithMany(p => p.ExContactData)
                .HasForeignKey(d => d.ExporterTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Exporter_Contact_A_SystemCode");
        });

        modelBuilder.Entity<ExContactDatum1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Company_ContactType");

            entity.ToTable("Ex_ContactData", "rejection");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ContactTypeId).HasColumnName("ContactType_ID");
            entity.Property(e => e.ExporterId).HasColumnName("Exporter_ID");
            entity.Property(e => e.ExporterTypeId).HasColumnName("ExporterType_Id");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
            entity.Property(e => e.Value).HasMaxLength(150);
        });

        modelBuilder.Entity<ExCountryConstrain>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CountryConstrain");

            entity.ToTable("Ex_CountryConstrain", tb => tb.HasComment("الاشترطات الدوليه"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ImportCountryId)
                .HasComment("الدولة المستوردة")
                .HasColumnName("Import_Country_ID");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasComment("");
            entity.Property(e => e.IsCompanyAccreditation)
                .HasDefaultValue(false)
                .HasComment("هل شركة معتمدة");
            entity.Property(e => e.IsFarmAccreditation)
                .HasDefaultValue(false)
                .HasComment("هل مزرعة معتمدة");
            entity.Property(e => e.IsStationAccreditation)
                .HasDefaultValue(false)
                .HasComment("هل محطة معتمدة");
            entity.Property(e => e.ItemCategoriesId).HasColumnName("ItemCategories_ID");
            entity.Property(e => e.ItemShortNameId)
                .HasComment("product or plant ID manual no relation")
                .HasColumnName("Item_ShortName_id");
            entity.Property(e => e.TransportCountryId)
                .HasComment("دولة عبور")
                .HasColumnName("TransportCountry_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ItemShortName).WithMany(p => p.ExCountryConstrains)
                .HasForeignKey(d => d.ItemShortNameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ex_CountryConstrain_Item_ShortName");
        });

        modelBuilder.Entity<ExCountryConstrainAnalysisLabType>(entity =>
        {
            entity.ToTable("Ex_CountryConstrain_AnalysisLabType", tb => tb.HasComment("تحاليل الاشتراطات"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AnalysisTypeId).HasColumnName("AnalysisTypeID");
            entity.Property(e => e.CountryConstrainId).HasColumnName("CountryConstrain_ID");
            entity.Property(e => e.IsAcive).HasComment("1 لو مفعل انه يظهر في الشهادة الزراعية");
            entity.Property(e => e.ParentId).HasColumnName("Parent_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.AnalysisType).WithMany(p => p.ExCountryConstrainAnalysisLabTypes)
                .HasForeignKey(d => d.AnalysisTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ex_CountryConstrain_AnalysisLabType_AnalysisType");

            entity.HasOne(d => d.CountryConstrain).WithMany(p => p.ExCountryConstrainAnalysisLabTypes)
                .HasForeignKey(d => d.CountryConstrainId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ex_CountryConstrain_AnalysisLabType_Ex_CountryConstrain");
        });

        modelBuilder.Entity<ExCountryConstrainArrivalPort>(entity =>
        {
            entity.ToTable("Ex_CountryConstrain_ArrivalPort", tb => tb.HasComment("موانى تحديد ميناء وصول معين"));

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ExCountryConstrainId).HasColumnName("Ex_CountryConstrain_Id");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasComment("");
            entity.Property(e => e.ParentId).HasColumnName("Parent_ID");
            entity.Property(e => e.PortInternationalId).HasColumnName("Port_International_Id");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");

            entity.HasOne(d => d.ExCountryConstrain).WithMany(p => p.ExCountryConstrainArrivalPorts)
                .HasForeignKey(d => d.ExCountryConstrainId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ex_CountryConstrain_ArrivalPort_Ex_CountryConstrain");

            entity.HasOne(d => d.PortInternational).WithMany(p => p.ExCountryConstrainArrivalPorts)
                .HasForeignKey(d => d.PortInternationalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ex_CountryConstrain_ArrivalPort_Port_International");
        });

        modelBuilder.Entity<ExCountryConstrainText>(entity =>
        {
            entity.ToTable("Ex_CountryConstrain_Text", tb => tb.HasComment("نصوص الاشتراطات"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CountryConstrainId).HasColumnName("CountryConstrain_ID");
            entity.Property(e => e.ExConstrainTextId).HasColumnName("EX_Constrain_Text_ID");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasComment("");
            entity.Property(e => e.ParentId).HasColumnName("Parent_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.CountryConstrain).WithMany(p => p.ExCountryConstrainTexts)
                .HasForeignKey(d => d.CountryConstrainId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ex_CountryConstrain_Text_Ex_CountryConstrain");

            entity.HasOne(d => d.ExConstrainText).WithMany(p => p.ExCountryConstrainTexts)
                .HasForeignKey(d => d.ExConstrainTextId)
                .HasConstraintName("FK_Ex_CountryConstrain_Text_EX_Constrain_Text");
        });

        modelBuilder.Entity<ExCountryConstrainTreatment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CountryConstrain_Treatment");

            entity.ToTable("Ex_CountryConstrain_Treatment", tb => tb.HasComment("معالجات الاشتراطات"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CountryConstrainId).HasColumnName("CountryConstrain_ID");
            entity.Property(e => e.ExposureDay).HasColumnName("Exposure_Day");
            entity.Property(e => e.ExposureHour).HasColumnName("Exposure_Hour");
            entity.Property(e => e.ExposureMinute).HasColumnName("Exposure_Minute");
            entity.Property(e => e.IsAcive).HasComment("1 لو مفعل انه يظهر في الشهادة الزراعية");
            entity.Property(e => e.IsOptional)
                .HasComment("التحليل اختيارى =0 \r\nالتحليل اجباري =1")
                .HasColumnName("IS_Optional");
            entity.Property(e => e.ParentId).HasColumnName("Parent_ID");
            entity.Property(e => e.TheDose)
                .HasComment("الجرعة")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.TreatmentMethodsId).HasColumnName("TreatmentMethods_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.CountryConstrain).WithMany(p => p.ExCountryConstrainTreatments)
                .HasForeignKey(d => d.CountryConstrainId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CountryConstrain_Treatment_CountryConstrain");

            entity.HasOne(d => d.TreatmentMethods).WithMany(p => p.ExCountryConstrainTreatments)
                .HasForeignKey(d => d.TreatmentMethodsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ex_CountryConstrain_Treatment_TreatmentMethods");
        });

        modelBuilder.Entity<ExFeesType>(entity =>
        {
            entity.ToTable("EX_Fees_Type");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AccountType)
                .HasComment("نوع الحساب من system code رقم 33")
                .HasColumnName("Account_Type");
            entity.Property(e => e.FeesActionId)
                .HasComment("نوع الوردية وقيمتها")
                .HasColumnName("Fees_Action_ID");
            entity.Property(e => e.FeesType)
                .HasComment("صادر وارد ورية مهندس\r\nرقم 20\r\nفى system code\r\n")
                .HasColumnName("Fees_Type");
            entity.Property(e => e.Value).HasColumnType("money");
        });

        modelBuilder.Entity<ExFinalResult>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Ex_Final_Position");

            entity.ToTable("Ex_Final_Result");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ArName).HasColumnName("Ar_Name");
            entity.Property(e => e.EnName)
                .IsUnicode(false)
                .HasColumnName("En_Name");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<ExList>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Ex_List");

            entity.Property(e => e.CenterId).HasColumnName("Center_ID");
            entity.Property(e => e.ClosedRequest).HasColumnName("Closed_Request");
            entity.Property(e => e.CreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.ExCheckRequestId).HasColumnName("Ex_CheckRequest_ID");
            entity.Property(e => e.ExportCountryName).HasMaxLength(100);
            entity.Property(e => e.F).HasColumnName("f");
            entity.Property(e => e.FinalResultId).HasColumnName("Final_Result_ID");
            entity.Property(e => e.FinalResultName).HasColumnName("Final_Result_Name");
            entity.Property(e => e.G).HasColumnName("g");
            entity.Property(e => e.ImCheckRequestNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ImCheckRequest_Number");
            entity.Property(e => e.ImporterId).HasColumnName("Importer_ID");
            entity.Property(e => e.ImporterTypeId).HasColumnName("ImporterType_Id");
            entity.Property(e => e.ImporterTypeName).HasMaxLength(150);
            entity.Property(e => e.OutletExaminationId).HasColumnName("Outlet_Examination_ID");
            entity.Property(e => e.OutletExaminationName).HasColumnName("Outlet_Examination_Name");
            entity.Property(e => e.OutletGenshiId).HasColumnName("Outlet_Genshi_ID");
            entity.Property(e => e.OutletGenshiName).HasColumnName("Outlet_Genshi_Name");
            entity.Property(e => e.OutletId).HasColumnName("Outlet_ID");
            entity.Property(e => e.OutletUserId).HasColumnName("Outlet_User_ID");
            entity.Property(e => e.OutletUserName).HasColumnName("Outlet_User_Name");
            entity.Property(e => e.StationExaminationId).HasColumnName("Station_Examination_ID");
            entity.Property(e => e.StationExaminationName).HasColumnName("Station_Examination_Name");
            entity.Property(e => e.StationGenshiId).HasColumnName("Station_Genshi_ID");
            entity.Property(e => e.StationGenshiName).HasColumnName("Station_Genshi_Name");
        });

        modelBuilder.Entity<ExList2>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Ex_List2");

            entity.Property(e => e.CenterId).HasColumnName("Center_ID");
            entity.Property(e => e.ClosedRequest).HasColumnName("Closed_Request");
            entity.Property(e => e.CreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.ExCheckRequestId).HasColumnName("Ex_CheckRequest_ID");
            entity.Property(e => e.ExportCountryId).HasColumnName("ExportCountryID");
            entity.Property(e => e.ExportCountryName).HasMaxLength(100);
            entity.Property(e => e.F).HasColumnName("f");
            entity.Property(e => e.FinalResultId).HasColumnName("Final_Result_ID");
            entity.Property(e => e.FinalResultName).HasColumnName("Final_Result_Name");
            entity.Property(e => e.G).HasColumnName("g");
            entity.Property(e => e.ImCheckRequestNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ImCheckRequest_Number");
            entity.Property(e => e.ImporterId).HasColumnName("Importer_ID");
            entity.Property(e => e.ImporterTypeId).HasColumnName("ImporterType_Id");
            entity.Property(e => e.ImporterTypeName).HasMaxLength(150);
            entity.Property(e => e.OutletExaminationId).HasColumnName("Outlet_Examination_ID");
            entity.Property(e => e.OutletExaminationName).HasColumnName("Outlet_Examination_Name");
            entity.Property(e => e.OutletGenshiId).HasColumnName("Outlet_Genshi_ID");
            entity.Property(e => e.OutletGenshiName).HasColumnName("Outlet_Genshi_Name");
            entity.Property(e => e.OutletId).HasColumnName("Outlet_ID");
            entity.Property(e => e.OutletUserId).HasColumnName("Outlet_User_ID");
            entity.Property(e => e.OutletUserName).HasColumnName("Outlet_User_Name");
            entity.Property(e => e.StationExaminationId).HasColumnName("Station_Examination_ID");
            entity.Property(e => e.StationExaminationName).HasColumnName("Station_Examination_Name");
            entity.Property(e => e.StationGenshiId).HasColumnName("Station_Genshi_ID");
            entity.Property(e => e.StationGenshiName).HasColumnName("Station_Genshi_Name");
        });

        modelBuilder.Entity<ExListOld>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Ex_ListOld");

            entity.Property(e => e.CenterId).HasColumnName("Center_ID");
            entity.Property(e => e.ClosedRequest).HasColumnName("Closed_Request");
            entity.Property(e => e.CreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.ExCheckRequestId).HasColumnName("Ex_CheckRequest_ID");
            entity.Property(e => e.ExportCountryName).HasMaxLength(100);
            entity.Property(e => e.F).HasColumnName("f");
            entity.Property(e => e.FinalResultId).HasColumnName("Final_Result_ID");
            entity.Property(e => e.FinalResultName).HasColumnName("Final_Result_Name");
            entity.Property(e => e.G).HasColumnName("g");
            entity.Property(e => e.ImCheckRequestNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ImCheckRequest_Number");
            entity.Property(e => e.ImporterId).HasColumnName("Importer_ID");
            entity.Property(e => e.ImporterTypeId).HasColumnName("ImporterType_Id");
            entity.Property(e => e.ImporterTypeName).HasMaxLength(150);
            entity.Property(e => e.OutletExaminationId).HasColumnName("Outlet_Examination_ID");
            entity.Property(e => e.OutletExaminationName).HasColumnName("Outlet_Examination_Name");
            entity.Property(e => e.OutletGenshiId).HasColumnName("Outlet_Genshi_ID");
            entity.Property(e => e.OutletGenshiName).HasColumnName("Outlet_Genshi_Name");
            entity.Property(e => e.OutletId).HasColumnName("Outlet_ID");
            entity.Property(e => e.OutletUserId).HasColumnName("Outlet_User_ID");
            entity.Property(e => e.OutletUserName).HasColumnName("Outlet_User_Name");
            entity.Property(e => e.StationExaminationId).HasColumnName("Station_Examination_ID");
            entity.Property(e => e.StationExaminationName).HasColumnName("Station_Examination_Name");
            entity.Property(e => e.StationGenshiId).HasColumnName("Station_Genshi_ID");
            entity.Property(e => e.StationGenshiName).HasColumnName("Station_Genshi_Name");
        });

        modelBuilder.Entity<ExListQuick>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Ex_ListQuick");

            entity.Property(e => e.CenterId).HasColumnName("Center_ID");
            entity.Property(e => e.ClosedRequest).HasColumnName("Closed_Request");
            entity.Property(e => e.CreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.ExCheckRequestId).HasColumnName("Ex_CheckRequest_ID");
            entity.Property(e => e.ExportCountryName).HasMaxLength(100);
            entity.Property(e => e.F).HasColumnName("f");
            entity.Property(e => e.FinalResultId).HasColumnName("Final_Result_ID");
            entity.Property(e => e.FinalResultName).HasColumnName("Final_Result_Name");
            entity.Property(e => e.G).HasColumnName("g");
            entity.Property(e => e.ImCheckRequestNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ImCheckRequest_Number");
            entity.Property(e => e.ImporterId).HasColumnName("Importer_ID");
            entity.Property(e => e.ImporterTypeId).HasColumnName("ImporterType_Id");
            entity.Property(e => e.ImporterTypeName).HasMaxLength(150);
            entity.Property(e => e.OutletExaminationId).HasColumnName("Outlet_Examination_ID");
            entity.Property(e => e.OutletExaminationName).HasColumnName("Outlet_Examination_Name");
            entity.Property(e => e.OutletGenshiId).HasColumnName("Outlet_Genshi_ID");
            entity.Property(e => e.OutletGenshiName).HasColumnName("Outlet_Genshi_Name");
            entity.Property(e => e.OutletId).HasColumnName("Outlet_ID");
            entity.Property(e => e.OutletUserId).HasColumnName("Outlet_User_ID");
            entity.Property(e => e.OutletUserName).HasColumnName("Outlet_User_Name");
            entity.Property(e => e.StationExaminationId).HasColumnName("Station_Examination_ID");
            entity.Property(e => e.StationExaminationName).HasColumnName("Station_Examination_Name");
            entity.Property(e => e.StationGenshiId).HasColumnName("Station_Genshi_ID");
            entity.Property(e => e.StationGenshiName).HasColumnName("Station_Genshi_Name");
        });

        modelBuilder.Entity<ExOpertaionType>(entity =>
        {
            entity.ToTable("Ex_OpertaionType");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name_En");
            entity.Property(e => e.WithPermission).HasColumnName("withPermission");
        });

        modelBuilder.Entity<ExRequestCommittee>(entity =>
        {
            entity.ToTable("Ex_RequestCommittee");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CommitteeTypeId).HasColumnName("CommitteeType_ID");
            entity.Property(e => e.DelegationDate).HasColumnName("Delegation_Date");
            entity.Property(e => e.ExCheckRequestId).HasColumnName("ExCheckRequest_ID");
            entity.Property(e => e.ExCommitteeCheckLocationId).HasColumnName("ExCommitteeCheckLocation_ID");
            entity.Property(e => e.IsApproved).HasDefaultValue(false);
            entity.Property(e => e.IsCancel)
                .HasComment("لايقاف او حذف اللجنة مربوط مع  A_SystemCode رقم 31\r\n")
                .HasColumnName("Is_Cancel");
            entity.Property(e => e.IsFinishedAll).HasDefaultValue(false);
            entity.Property(e => e.IsPaid)
                .HasDefaultValue(false)
                .HasComment("تم الانتهاء من الدفع");
            entity.Property(e => e.IsStartAndroid)
                .HasComment("تعزر عمل اللجنه")
                .HasColumnName("Is_Start_Android");
            entity.Property(e => e.Status).HasDefaultValue(false);
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.CommitteeType).WithMany(p => p.ExRequestCommittees)
                .HasForeignKey(d => d.CommitteeTypeId)
                .HasConstraintName("FK_Ex_RequestCommittee_CommitteeType");

            entity.HasOne(d => d.ExCheckRequest).WithMany(p => p.ExRequestCommittees)
                .HasForeignKey(d => d.ExCheckRequestId)
                .HasConstraintName("FK_Ex_RequestCommittee_Ex_CheckRequest");

            entity.HasOne(d => d.ExCommitteeCheckLocation).WithMany(p => p.ExRequestCommittees)
                .HasForeignKey(d => d.ExCommitteeCheckLocationId)
                .HasConstraintName("FK_Ex_RequestCommittee_Ex_CommitteeCheckLocation");
        });

        modelBuilder.Entity<ExRequestCommitteeFeesEng>(entity =>
        {
            entity.ToTable("Ex_RequestCommittee_Fees_ENG");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ExFeesTypeId).HasColumnName("Ex_Fees_Type_ID");
            entity.Property(e => e.ExRequestCommitteeId).HasColumnName("Ex_RequestCommittee_ID");
            entity.Property(e => e.IsPaid)
                .HasDefaultValue(false)
                .HasComment("تم الانتهاء من الدفع");
            entity.Property(e => e.NumEng)
                .HasDefaultValue(1)
                .HasColumnName("Num_Eng");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
            entity.Property(e => e.Value).HasColumnType("money");

            entity.HasOne(d => d.ExFeesType).WithMany(p => p.ExRequestCommitteeFeesEngs)
                .HasForeignKey(d => d.ExFeesTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ex_RequestCommittee_Fees_ENG_EX_Fees_Type");

            entity.HasOne(d => d.ExRequestCommittee).WithMany(p => p.ExRequestCommitteeFeesEngs)
                .HasForeignKey(d => d.ExRequestCommitteeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ex_RequestCommittee_Fees_ENG_Ex_RequestCommittee");
        });

        modelBuilder.Entity<ExRequestCommitteeShift>(entity =>
        {
            entity.ToTable("Ex_RequestCommittee_Shift");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.ExRequestCommitteeId).HasColumnName("Ex_RequestCommittee_ID");
            entity.Property(e => e.ShiftTimingId).HasColumnName("ShiftTiming_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ExRequestCommittee).WithMany(p => p.ExRequestCommitteeShifts)
                .HasForeignKey(d => d.ExRequestCommitteeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ex_RequestCommittee_Shift_Ex_RequestCommittee");

            entity.HasOne(d => d.ShiftTiming).WithMany(p => p.ExRequestCommitteeShifts)
                .HasForeignKey(d => d.ShiftTimingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ex_RequestCommittee_Shift_ShiftTiming");
        });

        modelBuilder.Entity<ExRequestTreatmentDataConfirm>(entity =>
        {
            entity.ToTable("Ex_Request_TreatmentData_Confirm");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnType("smalldatetime");
            entity.Property(e => e.ExRequestTreatmentDataId).HasColumnName("Ex_Request_TreatmentData_ID");
            entity.Property(e => e.IsAccepted).HasDefaultValue(true);

            entity.HasOne(d => d.ExRequestTreatmentData).WithMany(p => p.ExRequestTreatmentDataConfirms)
                .HasForeignKey(d => d.ExRequestTreatmentDataId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ex_Request_TreatmentData_Confirm_Ex_Request_TreatmentData");
        });

        modelBuilder.Entity<ExRequestTreatmentDatum>(entity =>
        {
            entity.ToTable("Ex_Request_TreatmentData");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Amount)
                .HasComment("المبلغ")
                .HasColumnType("money");
            entity.Property(e => e.CompanyId).HasColumnName("Company_ID");
            entity.Property(e => e.ExRequestCommitteeId).HasColumnName("Ex_RequestCommittee_ID");
            entity.Property(e => e.ExRequestItemId).HasColumnName("Ex_Request_Item_Id");
            entity.Property(e => e.ExRequestLotDataId).HasColumnName("Ex_Request_LotData_ID");
            entity.Property(e => e.ExposureDay).HasColumnName("Exposure_Day");
            entity.Property(e => e.ExposureHour).HasColumnName("Exposure_Hour");
            entity.Property(e => e.ExposureMinute).HasColumnName("Exposure_Minute");
            entity.Property(e => e.FeesActual)
                .HasColumnType("money")
                .HasColumnName("Fees_Actual");
            entity.Property(e => e.IsFromAndroid)
                .HasDefaultValue(false)
                .HasColumnName("IS_From_Android");
            entity.Property(e => e.IsPaid).HasDefaultValue(false);
            entity.Property(e => e.IsTotal).HasColumnName("IS_Total");
            entity.Property(e => e.IsTotalAndroid).HasColumnName("IS_Total_Android");
            entity.Property(e => e.ItemShortNameId).HasColumnName("Item_ShortName_ID");
            entity.Property(e => e.Size).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.StationId).HasColumnName("Station_ID");
            entity.Property(e => e.StationPlace).HasColumnName("Station_Place");
            entity.Property(e => e.Temperature).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.TheDose).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.ThermalSealNumber).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.TreatmentMatAmount)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("TreatmentMat_Amount");
            entity.Property(e => e.TreatmentMatId).HasColumnName("TreatmentMat_ID");
            entity.Property(e => e.TreatmentMethodId).HasColumnName("TreatmentMethod_ID");
            entity.Property(e => e.TreatmentTypeId).HasColumnName("TreatmentType_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ExRequestCommittee).WithMany(p => p.ExRequestTreatmentData)
                .HasForeignKey(d => d.ExRequestCommitteeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ex_Request_TreatmentData_Im_RequestCommittee");

            entity.HasOne(d => d.TreatmentMat).WithMany(p => p.ExRequestTreatmentData)
                .HasForeignKey(d => d.TreatmentMatId)
                .HasConstraintName("FK_Ex_Request_TreatmentData_TreatmentMaterial");
        });

        modelBuilder.Entity<ExVisa>(entity =>
        {
            entity.ToTable("Ex_Visa", tb => tb.HasComment("التاشيره"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ArName)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Ar_Name");
            entity.Property(e => e.DescriptionAr).HasColumnName("Description_Ar");
            entity.Property(e => e.DescriptionEn).HasColumnName("Description_En");
            entity.Property(e => e.EnName)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("En_Name");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<Family>(entity =>
        {
            entity.ToTable("Family", tb => tb.HasComment("العائله"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("Name_En");
            entity.Property(e => e.OrderId).HasColumnName("Order_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.Order).WithMany(p => p.Families)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_Family_Order");
        });

        modelBuilder.Entity<FarmCheckList>(entity =>
        {
            entity.ToTable("Farm_CheckList");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ConstrainTextAr).HasColumnName("ConstrainText_Ar");
            entity.Property(e => e.ConstrainTextEn)
                .IsUnicode(false)
                .HasColumnName("ConstrainText_En");
            entity.Property(e => e.DescriptionAr).HasColumnName("Description_Ar");
            entity.Property(e => e.DescriptionEn)
                .IsUnicode(false)
                .HasColumnName("Description_En");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasComment("");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<FarmCommittee>(entity =>
        {
            entity.ToTable("Farm_Committee", tb => tb.HasComment("تشكيل لجنة مزرعة"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AmountTotal)
                .HasComment("المبلغ")
                .HasColumnType("money")
                .HasColumnName("Amount_Total");
            entity.Property(e => e.AnalysisCount)
                .HasDefaultValue((byte)0)
                .HasComment("عدد السحبات")
                .HasColumnName("analysis_count");
            entity.Property(e => e.CommitteeTypeId).HasColumnName("CommitteeType_ID");
            entity.Property(e => e.DelegationDate)
                .HasComment("تاريخ الفحص-تاريخ الانتداب")
                .HasColumnName("Delegation_Date");
            entity.Property(e => e.EndTime).HasComment("انتهاء ساعة الفحص");
            entity.Property(e => e.FarmRequestId)
                .HasComment("طلب الفحص")
                .HasColumnName("Farm_Request_ID");
            entity.Property(e => e.IsApproved).HasComment("null->exporter not take action \r\n0 if exporter doesn't accept else 1\r\n\r\nnull تم طلب لجنة\r\n0 تم رفض الطلب من العميل\r\n1 تم قبول الطلب من العميل\r\n");
            entity.Property(e => e.IsCancel)
                .HasComment("تعزر عمل اللجنه")
                .HasColumnName("Is_Cancel");
            entity.Property(e => e.IsFinishedAll)
                .HasDefaultValue(false)
                .HasComment("0 if exporter doesn't accept else 1  خاص ب شغل موظف الحجر في فحص الشحنه");
            entity.Property(e => e.IsPaid)
                .HasDefaultValue(false)
                .HasComment("تم الانتهاء من الدفع");
            entity.Property(e => e.IsStartAndroid)
                .HasComment("تعزر عمل اللجنه")
                .HasColumnName("Is_Start_Android");
            entity.Property(e => e.RefuseReasonNots)
                .HasComment("اسباب الرفض")
                .HasColumnName("Refuse_Reason_Nots");
            entity.Property(e => e.ShiftTimingId).HasColumnName("ShiftTiming_ID");
            entity.Property(e => e.StartTime).HasComment(" بداية ساعة الفحص ");
            entity.Property(e => e.Status).HasComment("null->No committe ,0 if not done, 1 if investigation is done\r\n\r\nnull لم يتم تشكيل اللجنة\r\n0 تم التشكيل ولم يتم خروج اللجنة\r\n1 انتهاء عمل اللجنة\r\n");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.CommitteeType).WithMany(p => p.FarmCommittees)
                .HasForeignKey(d => d.CommitteeTypeId)
                .HasConstraintName("FK_Farm_Committee_CommitteeType");

            entity.HasOne(d => d.FarmRequest).WithMany(p => p.FarmCommittees)
                .HasForeignKey(d => d.FarmRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Farm_Committee_Farm_Country_Request");
        });

        modelBuilder.Entity<FarmCommitteeCheckList>(entity =>
        {
            entity.ToTable("Farm_Committee_CheckList");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.EmployeeIdQuarantine).HasColumnName("EmployeeId_Quarantine");
            entity.Property(e => e.FarmCommitteeId)
                .HasComment("لجنة المعالجة")
                .HasColumnName("FarmCommittee_ID");
            entity.Property(e => e.FarmCountryCheckListId).HasColumnName("Farm_Country_CheckList_ID");
            entity.Property(e => e.IsAccepted).HasComment("0 if rejected else 1 \r\nlab will set the result");
            entity.Property(e => e.IsAcceptedQuarantine)
                .HasComment("0 if rejected else 1 \r\nlab will set the result")
                .HasColumnName("IsAccepted_Quarantine");
            entity.Property(e => e.NotesAr)
                .HasMaxLength(300)
                .HasColumnName("Notes_Ar");
            entity.Property(e => e.NotesEn)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("Notes_En");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId)
                .HasComment("Employee ID")
                .HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.FarmCommittee).WithMany(p => p.FarmCommitteeCheckLists)
                .HasForeignKey(d => d.FarmCommitteeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Farm_Committee_CheckList_Farm_Committee");

            entity.HasOne(d => d.FarmCountryCheckList).WithMany(p => p.FarmCommitteeCheckLists)
                .HasForeignKey(d => d.FarmCountryCheckListId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Farm_Committee_CheckList_Farm_Country_CheckList");
        });

        modelBuilder.Entity<FarmCommitteeCheckListConfirm>(entity =>
        {
            entity.ToTable("Farm_Committee_CheckList_Confirm");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnType("smalldatetime");
            entity.Property(e => e.FarmCommitteeCheckListId).HasColumnName("Farm_Committee_CheckList_ID");
            entity.Property(e => e.IsAccepted).HasDefaultValue(true);
            entity.Property(e => e.Notes).HasMaxLength(500);

            entity.HasOne(d => d.FarmCommitteeCheckList).WithMany(p => p.FarmCommitteeCheckListConfirms)
                .HasForeignKey(d => d.FarmCommitteeCheckListId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Farm_Committee_CheckList_Confirm_Farm_Committee_CheckList");
        });

        modelBuilder.Entity<FarmCommitteeConstrain>(entity =>
        {
            entity.ToTable("Farm_Committee_Constrain", tb => tb.HasComment("لجنه المزرعه"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.FarmCommitteeId).HasColumnName("Farm_Committee_ID");
            entity.Property(e => e.FarmConstrainId).HasColumnName("Farm_Constrain_ID");

            entity.HasOne(d => d.FarmCommittee).WithMany(p => p.FarmCommitteeConstrains)
                .HasForeignKey(d => d.FarmCommitteeId)
                .HasConstraintName("FK_Farm_Committee_Constrain_Farm_Committee");

            entity.HasOne(d => d.FarmConstrain).WithMany(p => p.FarmCommitteeConstrains)
                .HasForeignKey(d => d.FarmConstrainId)
                .HasConstraintName("FK_Farm_Committee_Constrain_Farm_Constrain");
        });

        modelBuilder.Entity<FarmCommitteeExamination>(entity =>
        {
            entity.ToTable("Farm_Committee_Examination", tb => tb.HasComment("معاينة المزرعة"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AdminConfirmation)
                .HasComment("موقف الحجر")
                .HasColumnName("Admin_Confirmation");
            entity.Property(e => e.AdminDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Admin_Date");
            entity.Property(e => e.AdminFinalResultNote)
                .HasComment("Admin Note")
                .HasColumnName("AdminFinalResult_Note");
            entity.Property(e => e.AdminUser)
                .HasComment("ادمن الحجر")
                .HasColumnName("Admin_User");
            entity.Property(e => e.AreaAcres).HasColumnName("Area_Acres");
            entity.Property(e => e.EndDate).HasComment("تاريخ نهاية معاينة الصنف");
            entity.Property(e => e.FarmCommitteeId)
                .HasComment("لجنة المعالجة")
                .HasColumnName("FarmCommittee_ID");
            entity.Property(e => e.FarmRequestItemCategoriesId).HasColumnName("Farm_Request_ItemCategories_ID");
            entity.Property(e => e.IsAccepted).HasComment("0 if rejected else 1");
            entity.Property(e => e.IsAdminFinalResult).HasComment("null->exporter not take action 0 if exporter doesn't accept else 1");
            entity.Property(e => e.Notes).HasMaxLength(300);
            entity.Property(e => e.QuantityTon)
                .HasComment("الانتاجية")
                .HasColumnName("Quantity_Ton");
            entity.Property(e => e.StartDate).HasComment("تاريخ بداية معاينة الصنف");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");

            entity.HasOne(d => d.FarmCommittee).WithMany(p => p.FarmCommitteeExaminations)
                .HasForeignKey(d => d.FarmCommitteeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Farm_Committee_Examination_Farm_Committee");

            entity.HasOne(d => d.FarmRequestItemCategories).WithMany(p => p.FarmCommitteeExaminations)
                .HasForeignKey(d => d.FarmRequestItemCategoriesId)
                .HasConstraintName("FK_Farm_Committee_Examination_Farm_Request_ItemCategories");
        });

        modelBuilder.Entity<FarmCommitteeExaminationConfirm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Farm_Committee_Confirm");

            entity.ToTable("Farm_Committee_Examination_Confirm", tb => tb.HasComment("الموافقة على نتيجة الفحص"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnType("smalldatetime");
            entity.Property(e => e.FarmCommitteeExminationId).HasColumnName("Farm_Committee_Exmination_ID");
            entity.Property(e => e.IsAccepted).HasDefaultValue(true);
            entity.Property(e => e.Notes).HasMaxLength(500);

            entity.HasOne(d => d.FarmCommitteeExmination).WithMany(p => p.FarmCommitteeExaminationConfirms)
                .HasForeignKey(d => d.FarmCommitteeExminationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Farm_Committee_Confirm_Farm_Committee_Examination");
        });

        modelBuilder.Entity<FarmCommitteeFinalResult>(entity =>
        {
            entity.ToTable("Farm_Committee_Final_Result");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.FarmCommitteeId)
                .HasComment("لجنة المعالجة")
                .HasColumnName("FarmCommittee_ID");
            entity.Property(e => e.Isadmin)
                .HasComment("is admin for the current committee")
                .HasColumnName("ISAdmin");
            entity.Property(e => e.NotesCheckList).HasColumnName("Notes_CheckList");
            entity.Property(e => e.NotesExamination).HasColumnName("Notes_Examination");
            entity.Property(e => e.NotesSampleData).HasColumnName("Notes_SampleData");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId)
                .HasComment("Employee ID")
                .HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.FarmCommittee).WithMany(p => p.FarmCommitteeFinalResults)
                .HasForeignKey(d => d.FarmCommitteeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Farm_Committee_Final_Result_Farm_Committee");
        });

        modelBuilder.Entity<FarmCommitteeShift>(entity =>
        {
            entity.ToTable("Farm_Committee_Shift");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Amount)
                .HasComment("المبلغ")
                .HasColumnType("money");
            entity.Property(e => e.FarmCommitteeId).HasColumnName("Farm_Committee_ID");
            entity.Property(e => e.ShiftTimingId).HasColumnName("ShiftTiming_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.FarmCommittee).WithMany(p => p.FarmCommitteeShifts)
                .HasForeignKey(d => d.FarmCommitteeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Farm_Committee_Shift_Farm_Committee");

            entity.HasOne(d => d.ShiftTiming).WithMany(p => p.FarmCommitteeShifts)
                .HasForeignKey(d => d.ShiftTimingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Farm_Committee_Shift_ShiftTiming");
        });

        modelBuilder.Entity<FarmCompany>(entity =>
        {
            entity.ToTable("Farm_Company", tb => tb.HasComment("الشركة او الهيئة او الفرد"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CompanyId).HasColumnName("Company_ID");
            entity.Property(e => e.EndDate).HasColumnName("End_Date");
            entity.Property(e => e.ExporterTypeId)
                .HasComment("from systemcode table 3")
                .HasColumnName("ExporterType_Id");
            entity.Property(e => e.FarmId).HasColumnName("Farm_ID");
            entity.Property(e => e.StartDate).HasColumnName("Start_Date");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.Farm).WithMany(p => p.FarmCompanies)
                .HasForeignKey(d => d.FarmId)
                .HasConstraintName("FK_Farm_Company_FarmsData");
        });

        modelBuilder.Entity<FarmConstrain>(entity =>
        {
            entity.ToTable("Farm_Constrain", tb => tb.HasComment("اشترطات المزارع"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AnalysisTypeId).HasColumnName("AnalysisType_ID");
            entity.Property(e => e.CountVisit).HasColumnName("Count_Visit");
            entity.Property(e => e.CountryId).HasColumnName("Country_Id");
            entity.Property(e => e.FarmConstrainTextId).HasColumnName("Farm_Constrain_Text_ID");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasComment("");
            entity.Property(e => e.IsPreview)
                .HasComment("المعاينة")
                .HasColumnName("Is_Preview");
            entity.Property(e => e.ItemId).HasColumnName("Item_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.AnalysisType).WithMany(p => p.FarmConstrains)
                .HasForeignKey(d => d.AnalysisTypeId)
                .HasConstraintName("FK_Farm_Constrain_AnalysisType");

            entity.HasOne(d => d.Country).WithMany(p => p.FarmConstrains)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_Farm_Constrain_Country");

            entity.HasOne(d => d.FarmConstrainText).WithMany(p => p.FarmConstrains)
                .HasForeignKey(d => d.FarmConstrainTextId)
                .HasConstraintName("FK_Farm_Constrain_Farm_Constrain_Text");

            entity.HasOne(d => d.Item).WithMany(p => p.FarmConstrains)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK_Farm_Constrain_Item");
        });

        modelBuilder.Entity<FarmConstrainText>(entity =>
        {
            entity.ToTable("Farm_Constrain_Text");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ConstrainTextAr).HasColumnName("ConstrainText_Ar");
            entity.Property(e => e.ConstrainTextEn)
                .IsUnicode(false)
                .HasColumnName("ConstrainText_En");
            entity.Property(e => e.DescriptionAr).HasColumnName("Description_Ar");
            entity.Property(e => e.DescriptionEn)
                .IsUnicode(false)
                .HasColumnName("Description_En");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasComment("");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<FarmCountry>(entity =>
        {
            entity.ToTable("Farm_Country");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CountryId)
                .HasComment("ConstrainOwner(UnionId/CountryId/ or 0 if Local-Egypt)")
                .HasColumnName("Country_ID");
            entity.Property(e => e.EndDate).HasColumnName("End_Date");
            entity.Property(e => e.FarmRequestId).HasColumnName("Farm_Request_ID");
            entity.Property(e => e.IsAcceppted).HasComment("الحجر واقف على الدولة ولا لا");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.StartDate).HasColumnName("Start_Date");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.Country).WithMany(p => p.FarmCountries)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_Farm_Country_Country");

            entity.HasOne(d => d.FarmRequest).WithMany(p => p.FarmCountries)
                .HasForeignKey(d => d.FarmRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Farm_Country_Farm_Request");
        });

        modelBuilder.Entity<FarmCountryCheckList>(entity =>
        {
            entity.ToTable("Farm_Country_CheckList");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CountryId).HasColumnName("Country_ID");
            entity.Property(e => e.FarmCheckListId).HasColumnName("Farm_CheckList_ID");
            entity.Property(e => e.ItemId).HasColumnName("Item_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.Country).WithMany(p => p.FarmCountryCheckLists)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_Farm_Country_CheckList_Country");

            entity.HasOne(d => d.FarmCheckList).WithMany(p => p.FarmCountryCheckLists)
                .HasForeignKey(d => d.FarmCheckListId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Farm_Country_CheckList_Farm_CheckList");

            entity.HasOne(d => d.Item).WithMany(p => p.FarmCountryCheckLists)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK_Farm_Country_CheckList_Item");
        });

        modelBuilder.Entity<FarmFee>(entity =>
        {
            entity.HasKey(e => e.FarmFeesId);

            entity.ToTable("Farm_Fees");

            entity.Property(e => e.FarmFeesId).HasColumnName("FarmFeesID");
            entity.Property(e => e.AcreEnd).HasColumnName("acreEnd");
            entity.Property(e => e.AcreStart).HasColumnName("acreStart");
            entity.Property(e => e.Fees)
                .HasColumnType("money")
                .HasColumnName("fees");
            entity.Property(e => e.UserCreationDate)
                .HasComment("null-> for user , value -> if the admin add the row")
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId)
                .HasComment("null-> for user , value -> if the admin add the row")
                .HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<FarmItemCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_FarmPlant");

            entity.ToTable("Farm_ItemCategories", tb => tb.HasComment("اصناف المزرعة"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AreaAcres)
                .HasComment("مساحة العميل")
                .HasColumnName("Area_Acres");
            entity.Property(e => e.AreaAcresQuarant)
                .HasComment("المساحة النهائية للحجر")
                .HasColumnName("Area_Acres_Quarant");
            entity.Property(e => e.FarmId).HasColumnName("Farm_ID");
            entity.Property(e => e.ItemCategoriesId).HasColumnName("ItemCategories_ID");
            entity.Property(e => e.QuantityTon)
                .HasComment("")
                .HasColumnName("Quantity_Ton");
            entity.Property(e => e.QuantityTonExport)
                .HasComment("الكمية الاجمالية الصالحة للتصدير")
                .HasColumnName("Quantity_Ton__Export");
            entity.Property(e => e.QuantityTonQuarant)
                .HasComment("الكمية للفدان بالطن للحجر")
                .HasColumnName("Quantity_Ton__Quarant");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.Farm).WithMany(p => p.FarmItemCategories)
                .HasForeignKey(d => d.FarmId)
                .HasConstraintName("FK_FarmPlant_FarmsData");

            entity.HasOne(d => d.ItemCategories).WithMany(p => p.FarmItemCategories)
                .HasForeignKey(d => d.ItemCategoriesId)
                .HasConstraintName("FK_FarmPlant_PlantCategories");
        });

        modelBuilder.Entity<FarmRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Farm_Country_Recoust");

            entity.ToTable("Farm_Request");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.EndDate).HasColumnName("End_Date");
            entity.Property(e => e.EndDateRequest).HasColumnName("End_Date_Request");
            entity.Property(e => e.FarmRequestTypeId).HasColumnName("Farm_Request_Type_ID");
            entity.Property(e => e.FarmsDataId).HasColumnName("FarmsData_ID");
            entity.Property(e => e.Fees).HasColumnType("money");
            entity.Property(e => e.FeesActual)
                .HasColumnType("money")
                .HasColumnName("Fees_Actual");
            entity.Property(e => e.IsFinalRequst)
                .HasComment("الموقف النهائي للطلب\r\nnull لم يتم العمل على الطلب\r\n0 يتم العمل على الطلب\r\n1 تم الانتهاء من العمل على الطلب")
                .HasColumnName("Is_Final_requst");
            entity.Property(e => e.IsOnlineOffline)
                .HasDefaultValue(false)
                .HasComment("from web/system\r\n1->online\r\n0->offline")
                .HasColumnName("IS_OnlineOffline");
            entity.Property(e => e.IsPaid).HasComment("تم الانتهاء من الدفع");
            entity.Property(e => e.IsStatus).HasComment("null لم يتم انتهاء العمل على الطلب\r\n0 تم رفض الطلب\r\n1 تم قبول الطلب\r\n");
            entity.Property(e => e.PrintText).HasColumnName("Print_Text");
            entity.Property(e => e.StartDate).HasColumnName("Start_Date");
            entity.Property(e => e.StartDateRequest).HasColumnName("Start_Date_Request");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.FarmRequestType).WithMany(p => p.FarmRequests)
                .HasForeignKey(d => d.FarmRequestTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Farm_Request_Farm_Request_Type");

            entity.HasOne(d => d.FarmsData).WithMany(p => p.FarmRequests)
                .HasForeignKey(d => d.FarmsDataId)
                .HasConstraintName("FK_Farm_Country_Request_FarmsData");
        });

        modelBuilder.Entity<FarmRequestItemCategory>(entity =>
        {
            entity.ToTable("Farm_Request_ItemCategories");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AdminDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Admin_Date");
            entity.Property(e => e.AdminUser)
                .HasComment("ادمن الحجر")
                .HasColumnName("Admin_User");
            entity.Property(e => e.AreaAcres)
                .HasComment("مساحة العميل")
                .HasColumnName("Area_Acres");
            entity.Property(e => e.AreaAcresQuarant)
                .HasComment("المساحة النهائية للحجر")
                .HasColumnName("Area_Acres_Quarant");
            entity.Property(e => e.FarmItemCategoriesId).HasColumnName("Farm_ItemCategories_ID");
            entity.Property(e => e.FarmRequestId).HasColumnName("Farm_Request_ID");
            entity.Property(e => e.QuantityTon)
                .HasComment("الكمية للطن")
                .HasColumnName("Quantity_Ton");
            entity.Property(e => e.QuantityTonExport)
                .HasComment("الكمية الاجمالية الصالحة للتصدير")
                .HasColumnName("Quantity_Ton__Export");
            entity.Property(e => e.QuantityTonQuarant)
                .HasComment("الكمية للفدان بالطن للحجر")
                .HasColumnName("Quantity_Ton__Quarant");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.FarmItemCategories).WithMany(p => p.FarmRequestItemCategories)
                .HasForeignKey(d => d.FarmItemCategoriesId)
                .HasConstraintName("FK_Farm_Request_ItemCategories_Farm_ItemCategories");

            entity.HasOne(d => d.FarmRequest).WithMany(p => p.FarmRequestItemCategories)
                .HasForeignKey(d => d.FarmRequestId)
                .HasConstraintName("FK_Farm_Request_ItemCategories_Farm_Request");
        });

        modelBuilder.Entity<FarmRequestRefuseReason>(entity =>
        {
            entity.ToTable("Farm_Request_Refuse_Reason");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.FarmRequestId).HasColumnName("Farm_Request_ID");
            entity.Property(e => e.RefuseReasonId).HasColumnName("Refuse_Reason_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.FarmRequest).WithMany(p => p.FarmRequestRefuseReasons)
                .HasForeignKey(d => d.FarmRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Farm_Request_Refuse_Reason_Farm_Request");

            entity.HasOne(d => d.RefuseReason).WithMany(p => p.FarmRequestRefuseReasons)
                .HasForeignKey(d => d.RefuseReasonId)
                .HasConstraintName("FK_Farm_Request_Refuse_Reason_Refuse_Reason");
        });

        modelBuilder.Entity<FarmRequestType>(entity =>
        {
            entity.ToTable("Farm_Request_Type");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_AR");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("Name_EN");
        });

        modelBuilder.Entity<FarmSampleDataConfirm>(entity =>
        {
            entity.ToTable("Farm_SampleData_Confirm");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnType("smalldatetime");
            entity.Property(e => e.FarmSampleDataId).HasColumnName("Farm_SampleData_ID");
            entity.Property(e => e.IsAccepted).HasDefaultValue(true);
            entity.Property(e => e.Notes).HasMaxLength(500);

            entity.HasOne(d => d.FarmSampleData).WithMany(p => p.FarmSampleDataConfirms)
                .HasForeignKey(d => d.FarmSampleDataId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Farm_SampleData_Confirm_Farm_SampleData");
        });

        modelBuilder.Entity<FarmSampleDataConfirmItem>(entity =>
        {
            entity.ToTable("Farm_SampleData_Confirm_Item");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnType("smalldatetime");
            entity.Property(e => e.FarmSampleDataItemId).HasColumnName("Farm_SampleData_Item_ID");
            entity.Property(e => e.IsAccepted).HasDefaultValue(true);
            entity.Property(e => e.Notes).HasMaxLength(500);

            entity.HasOne(d => d.FarmSampleDataItem).WithMany(p => p.FarmSampleDataConfirmItems)
                .HasForeignKey(d => d.FarmSampleDataItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Farm_SampleData_Confirm_Item_Farm_SampleData_Item");
        });

        modelBuilder.Entity<FarmSampleDataItem>(entity =>
        {
            entity.ToTable("Farm_SampleData_Item");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AdminConfirmation)
                .HasComment("موقف الحجر")
                .HasColumnName("Admin_Confirmation");
            entity.Property(e => e.AdminDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Admin_Date");
            entity.Property(e => e.AdminUser)
                .HasComment("ادمن الحجر")
                .HasColumnName("Admin_User");
            entity.Property(e => e.AnalysisLabTypeId).HasColumnName("AnalysisLabType_ID");
            entity.Property(e => e.FarmCommitteeId)
                .HasComment("لجنة المعالجة")
                .HasColumnName("FarmCommittee_ID");
            entity.Property(e => e.FarmRequestItemCategoriesId).HasColumnName("Farm_Request_ItemCategories_ID");
            entity.Property(e => e.IsAccepted).HasComment("0 if rejected else 1 \r\nموافقه المعمل");
            entity.Property(e => e.NotesAr)
                .HasMaxLength(300)
                .HasComment("ملاحظات الاندريد")
                .HasColumnName("Notes_Ar");
            entity.Property(e => e.NotesEn)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("Notes_En");
            entity.Property(e => e.RejectReasonAr)
                .HasMaxLength(150)
                .HasComment("سبب الرفض للمعمل ar")
                .HasColumnName("RejectReason_Ar");
            entity.Property(e => e.RejectReasonEn)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("سبب الرفض للمعمل en")
                .HasColumnName("RejectReason_En");
            entity.Property(e => e.SampleBarCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("البار كود")
                .HasColumnName("Sample_BarCode");
            entity.Property(e => e.SampleRatio).HasComment("نسبة اخذ العينة");
            entity.Property(e => e.SampleSize).HasComment("حجم العينة");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
            entity.Property(e => e.WithdrawDate).HasComment("تاريخ سحب العينة");

            entity.HasOne(d => d.AnalysisLabType).WithMany(p => p.FarmSampleDataItems)
                .HasForeignKey(d => d.AnalysisLabTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Farm_SampleData_Item_AnalysisLabType");

            entity.HasOne(d => d.FarmCommittee).WithMany(p => p.FarmSampleDataItems)
                .HasForeignKey(d => d.FarmCommitteeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Farm_SampleData_Item_Farm_Committee");

            entity.HasOne(d => d.FarmRequestItemCategories).WithMany(p => p.FarmSampleDataItems)
                .HasForeignKey(d => d.FarmRequestItemCategoriesId)
                .HasConstraintName("FK_Farm_SampleData_Item_Farm_Request_ItemCategories");
        });

        modelBuilder.Entity<FarmSampleDatum>(entity =>
        {
            entity.ToTable("Farm_SampleData", tb => tb.HasComment("عينة سحب المزرعة"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AdminConfirmation)
                .HasComment("موقف الحجر")
                .HasColumnName("Admin_Confirmation");
            entity.Property(e => e.AdminDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Admin_Date");
            entity.Property(e => e.AdminUser)
                .HasComment("ادمن الحجر")
                .HasColumnName("Admin_User");
            entity.Property(e => e.AnalysisLabTypeId).HasColumnName("AnalysisLabType_ID");
            entity.Property(e => e.FarmCommitteeId)
                .HasComment("لجنة المعالجة")
                .HasColumnName("FarmCommittee_ID");
            entity.Property(e => e.FarmRequestItemCategoriesId).HasColumnName("Farm_Request_ItemCategories_ID");
            entity.Property(e => e.IsAccepted).HasComment("0 if rejected else 1 \r\nموافقه المعمل");
            entity.Property(e => e.NotesAr)
                .HasMaxLength(300)
                .HasComment("ملاحظات الاندريد")
                .HasColumnName("Notes_Ar");
            entity.Property(e => e.NotesEn)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("Notes_En");
            entity.Property(e => e.RejectReasonAr)
                .HasMaxLength(150)
                .HasComment("سبب الرفض للمعمل ar")
                .HasColumnName("RejectReason_Ar");
            entity.Property(e => e.RejectReasonEn)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("سبب الرفض للمعمل en")
                .HasColumnName("RejectReason_En");
            entity.Property(e => e.SampleBarCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("البار كود")
                .HasColumnName("Sample_BarCode");
            entity.Property(e => e.SampleRatio).HasComment("نسبة اخذ العينة");
            entity.Property(e => e.SampleSize).HasComment("حجم العينة");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
            entity.Property(e => e.WithdrawDate).HasComment("تاريخ سحب العينة");

            entity.HasOne(d => d.AnalysisLabType).WithMany(p => p.FarmSampleData)
                .HasForeignKey(d => d.AnalysisLabTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Farm_SampleData_AnalysisLabType");

            entity.HasOne(d => d.FarmCommittee).WithMany(p => p.FarmSampleData)
                .HasForeignKey(d => d.FarmCommitteeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Farm_SampleData_Farm_Committee");

            entity.HasOne(d => d.FarmRequestItemCategories).WithMany(p => p.FarmSampleData)
                .HasForeignKey(d => d.FarmRequestItemCategoriesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Farm_SampleData_Farm_Request_ItemCategories");
        });

        modelBuilder.Entity<FarmStop>(entity =>
        {
            entity.ToTable("FarmStop");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<FarmsDatum>(entity =>
        {
            entity.ToTable(tb => tb.HasComment("المزرعة معتمدة"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AddressAr)
                .HasMaxLength(100)
                .HasColumnName("Address_Ar");
            entity.Property(e => e.AddressEn)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Address_En");
            entity.Property(e => e.CenterId).HasColumnName("Center_Id");
            entity.Property(e => e.FarmCode14)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FarmCode_14");
            entity.Property(e => e.FileUpload).IsUnicode(false);
            entity.Property(e => e.GovernId)
                .HasComment("المحافظة")
                .HasColumnName("Govern_ID");
            entity.Property(e => e.Gpsread)
                .HasMaxLength(50)
                .HasComment("قراءة GPS")
                .HasColumnName("GPSRead");
            entity.Property(e => e.IsApproved).HasComment("لو معتمدة 1");
            entity.Property(e => e.IsOnlineOffline)
                .HasDefaultValue(false)
                .HasComment("from web/system\r\n1->online\r\n0->offline")
                .HasColumnName("IS_OnlineOffline");
            entity.Property(e => e.ItemId).HasColumnName("Item_ID");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name_En");
            entity.Property(e => e.Status).HasComment("is null for default 0 is stopped for a time 1 is stopped permantely");
            entity.Property(e => e.ThePivot)
                .HasMaxLength(50)
                .HasComment("الحوض أو البيفوت");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
            entity.Property(e => e.VillageId)
                .HasComment("المراكز")
                .HasColumnName("Village_ID");

            entity.HasOne(d => d.Center).WithMany(p => p.FarmsData)
                .HasForeignKey(d => d.CenterId)
                .HasConstraintName("FK_FarmsData_Center");

            entity.HasOne(d => d.Govern).WithMany(p => p.FarmsData)
                .HasForeignKey(d => d.GovernId)
                .HasConstraintName("FK_FarmsData_Governate");

            entity.HasOne(d => d.Item).WithMany(p => p.FarmsData)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK_FarmsData_Item");

            entity.HasOne(d => d.Village).WithMany(p => p.FarmsData)
                .HasForeignKey(d => d.VillageId)
                .HasConstraintName("FK_FarmsData_Village");
        });

        modelBuilder.Entity<FarmsOrganizationDistributionDetial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Farm_Ex_CheckRequest_Distribution");

            entity.ToTable("Farms_Organization_Distribution_Detials");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.FarmsOrganizationDistributionMasterId).HasColumnName("Farms_Organization_Distribution_Master_ID");
            entity.Property(e => e.QuantityTon)
                .HasComment("الكمية الصالحة للتصدير")
                .HasColumnName("Quantity_Ton");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.FarmsOrganizationDistributionMaster).WithMany(p => p.FarmsOrganizationDistributionDetials)
                .HasForeignKey(d => d.FarmsOrganizationDistributionMasterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Farm_Ex_CheckRequest_Distribution_Farms_Organization_Distribution");
        });

        modelBuilder.Entity<FarmsOrganizationDistributionMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Farms_Organization");

            entity.ToTable("Farms_Organization_Distribution_Master");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.FarmItemCategoriesId).HasColumnName("Farm_ItemCategories_ID");
            entity.Property(e => e.FarmsDataId).HasColumnName("FarmsData_ID");
            entity.Property(e => e.ItemCategoriesId).HasColumnName("ItemCategories_ID");
            entity.Property(e => e.ItemId).HasColumnName("Item_ID");
            entity.Property(e => e.OrganizationId)
                .HasComment("رقم الجهة")
                .HasColumnName("Organization_ID");
            entity.Property(e => e.OrganizationTypeId)
                .HasComment("نوع الجهة")
                .HasColumnName("Organization_Type_Id");
            entity.Property(e => e.QuantityTonExCheckRequest).HasColumnName("Quantity_Ton_Ex_CheckRequest");
            entity.Property(e => e.QuantityTonFarm)
                .HasComment("الكمية الصالحة للتصدير")
                .HasColumnName("Quantity_Ton_Farm");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.FarmItemCategories).WithMany(p => p.FarmsOrganizationDistributionMasters)
                .HasForeignKey(d => d.FarmItemCategoriesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Farms_Organization_Distribution_Farm_ItemCategories");
        });

        modelBuilder.Entity<FeesAction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_FixedFeesAmount");

            entity.ToTable("Fees_Action", tb => tb.HasComment("تفاصيل الاجراءات"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AccountType)
                .HasComment("نوع الحساب من  system code رقم 33")
                .HasColumnName("Account_Type");
            entity.Property(e => e.Amount)
                .HasComment("المبلغ")
                .HasColumnType("money");
            entity.Property(e => e.CalculatorType).HasColumnName("Calculator_Type");
            entity.Property(e => e.FeerTypeActionId).HasColumnName("Feer_Type_Action_ID");
            entity.Property(e => e.FeesTypeId).HasColumnName("FeesType_Id");
            entity.Property(e => e.IsPaidBefore).HasComment("هل تدفع عند الطلب ام بعده");
            entity.Property(e => e.ItemShiftTreatmentId).HasColumnName("Item_Shift_Treatment_ID");
            entity.Property(e => e.MinAmount)
                .HasComment("الحد الادنى")
                .HasColumnType("money");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name_En");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
            entity.Property(e => e.WeightTo).HasComment("الوزن");

            entity.HasOne(d => d.FeerTypeAction).WithMany(p => p.FeesActions)
                .HasForeignKey(d => d.FeerTypeActionId)
                .HasConstraintName("FK_Fees_Action_Feer_Type_Action");

            entity.HasOne(d => d.FeesType).WithMany(p => p.FeesActions)
                .HasForeignKey(d => d.FeesTypeId)
                .HasConstraintName("FK_Fees_Action_FeesType");
        });

        modelBuilder.Entity<FeesAltahsil>(entity =>
        {
            entity.ToTable("Fees_Altahsil");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AccountType)
                .HasComment("نوع الحساب من system code رقم 33")
                .HasColumnName("Account_Type");
            entity.Property(e => e.AmountTotal)
                .HasComment("المبلغ")
                .HasColumnType("money")
                .HasColumnName("Amount_Total");
            entity.Property(e => e.CodeBank)
                .HasMaxLength(50)
                .HasComment("كود العملية من البنك")
                .HasColumnName("Code_Bank");
            entity.Property(e => e.CommercialRegister)
                .HasMaxLength(50)
                .HasColumnName("Commercial_Register");
            entity.Property(e => e.CustomsCertificateNumber)
                .HasMaxLength(200)
                .HasColumnName("Customs_Certificate_Number");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Department).HasMaxLength(250);
            entity.Property(e => e.IsSuccessBank)
                .HasComment("0 تم رفض عملية البنك\r\n1 تم قبول العملية \r\nnull تم الارسال ولم الرد من البنك")
                .HasColumnName("IsSuccess_Bank");
            entity.Property(e => e.IsUsed).HasColumnName("Is_Used");
            entity.Property(e => e.Item).HasMaxLength(250);
            entity.Property(e => e.LedgerNumber)
                .HasMaxLength(100)
                .HasColumnName("Ledger_Number");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NationalId)
                .HasMaxLength(14)
                .HasColumnName("National_ID");
            entity.Property(e => e.Office)
                .HasMaxLength(200)
                .HasColumnName("office");
            entity.Property(e => e.OrderNumber).HasMaxLength(50);
            entity.Property(e => e.PaymentTypeId)
                .HasComment("from systemcode table 30\r\nنوع عملية الدفع فيزا - كاش")
                .HasColumnName("Payment_Type_ID");
            entity.Property(e => e.TaxRegistry)
                .HasMaxLength(50)
                .HasColumnName("Tax_Registry");
            entity.Property(e => e.UsedByUserId).HasColumnName("Used_By_User_Id");
            entity.Property(e => e.UsedByUserName)
                .HasMaxLength(250)
                .HasColumnName("Used_By_User_Name");
            entity.Property(e => e.UsedDate)
                .HasPrecision(0)
                .HasColumnName("Used_Date");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");

            entity.HasOne(d => d.AccountTypeNavigation).WithMany(p => p.FeesAltahsilAccountTypeNavigations)
                .HasForeignKey(d => d.AccountType)
                .HasConstraintName("FK_Fees_Altahsil_A_SystemCode3");

            entity.HasOne(d => d.PaymentType).WithMany(p => p.FeesAltahsilPaymentTypes)
                .HasForeignKey(d => d.PaymentTypeId)
                .HasConstraintName("FK_Fees_Altahsil_A_SystemCode2");
        });

        modelBuilder.Entity<FeesAltahsilDetile>(entity =>
        {
            entity.ToTable("Fees_Altahsil_Detiles");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Amount)
                .HasComment("المبلغ")
                .HasColumnType("money");
            entity.Property(e => e.FeeDescription)
                .HasMaxLength(250)
                .HasColumnName("Fee_Description");
            entity.Property(e => e.FeesAltahsilId).HasColumnName("Fees_Altahsil_ID");
            entity.Property(e => e.FeesTypeId).HasColumnName("FeesType_ID");
            entity.Property(e => e.Quantity).HasComment("Ø§Ù„Ø¹Ø¯Ø¯");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");

            entity.HasOne(d => d.FeesAltahsil).WithMany(p => p.FeesAltahsilDetiles)
                .HasForeignKey(d => d.FeesAltahsilId)
                .HasConstraintName("FK_Fees_Altahsil_Detiles_Fees_Altahsil1");

            entity.HasOne(d => d.FeesType).WithMany(p => p.FeesAltahsilDetiles)
                .HasForeignKey(d => d.FeesTypeId)
                .HasConstraintName("FK_Fees_Altahsil_Detiles_FeesType1");
        });

        modelBuilder.Entity<FeesAmountFixed>(entity =>
        {
            entity.ToTable("FeesAmount_Fixed");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Amount)
                .HasComment("المبلغ")
                .HasColumnType("money");
            entity.Property(e => e.FeesTypeId).HasColumnName("FeesType_Id");
            entity.Property(e => e.IsPaidBefore).HasComment("هل تدفع عند الطلب ام بعده");
            entity.Property(e => e.MinAmount)
                .HasComment("الحد الادنى")
                .HasColumnType("money");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name_En");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
            entity.Property(e => e.WeightTo).HasComment("الوزن");

            entity.HasOne(d => d.FeesType).WithMany(p => p.FeesAmountFixeds)
                .HasForeignKey(d => d.FeesTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FeesAmount_Fixed_FeesType");
        });

        modelBuilder.Entity<FeesCertificatesPaymentDetile>(entity =>
        {
            entity.ToTable("Fees_Certificates_Payment_Detiles", tb => tb.HasComment("تفاصيل الدفع للشهادات"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CardOrGroupNumber)
                .HasMaxLength(50)
                .HasComment("رقم البطاقه(pos) او المجموعه(كاش) علي حسب طريقه الدفع");
            entity.Property(e => e.ExCertificatesRequestsId).HasColumnName("Ex_CertificatesRequests_ID");
            entity.Property(e => e.PaymentDate).HasComment("تاريخ الدفع");
            entity.Property(e => e.PosInformationId).HasColumnName("pos_information_id");
            entity.Property(e => e.ReferenceOrCouponNumber)
                .HasMaxLength(50)
                .HasComment("رقم مرجعي او القسيمه");

            entity.HasOne(d => d.ExCertificatesRequests).WithMany(p => p.FeesCertificatesPaymentDetiles)
                .HasForeignKey(d => d.ExCertificatesRequestsId)
                .HasConstraintName("FK_Fees_Certificates_Payment_Detiles_Ex_CertificatesRequests");
        });

        modelBuilder.Entity<FeesMoney>(entity =>
        {
            entity.ToTable("Fees_Money");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Fees).HasColumnType("money");
        });

        modelBuilder.Entity<FeesProcess>(entity =>
        {
            entity.ToTable("Fees_process", tb => tb.HasComment("انواع عمليات الرسوم - صادر وارد مزارع محطات"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<FeesTableName>(entity =>
        {
            entity.ToTable("Fees_TableName");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(150);
            entity.Property(e => e.TableName).HasMaxLength(100);
        });

        modelBuilder.Entity<FeesTransaction>(entity =>
        {
            entity.ToTable("Fees_Transactions");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AccountType)
                .HasComment("نوع الحساب من system code رقم 33")
                .HasColumnName("Account_Type");
            entity.Property(e => e.AmountTotal)
                .HasComment("المبلغ")
                .HasColumnType("money")
                .HasColumnName("Amount_Total");
            entity.Property(e => e.CodeBank)
                .HasMaxLength(50)
                .HasComment("كود العملية من البنك")
                .HasColumnName("Code_Bank");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.IsSuccessBank)
                .HasComment("0 تم رفض عملية البنك\r\n1 تم قبول العملية \r\nnull تم الارسال ولم الرد من البنك")
                .HasColumnName("IsSuccess_Bank");
            entity.Property(e => e.OrderNumber).HasMaxLength(14);
            entity.Property(e => e.PaymentTypeId)
                .HasComment("from systemcode table 30\r\nنوع عملية الدفع فيزا - كاش")
                .HasColumnName("Payment_Type_ID");
            entity.Property(e => e.TableId)
                .HasComment("id الجدول الرئيسي اللي متحدد في (fess_tablename)")
                .HasColumnName("Table_ID");
            entity.Property(e => e.TableNameId)
                .HasComment("id table (fees_tablename)")
                .HasColumnName("TableName_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserTypeId)
                .HasComment("from systemcode table 3\r\nنوع الموظف حجر ولا شركة ولا فرد ولاهيئه")
                .HasColumnName("User_Type_ID");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.TableName).WithMany(p => p.FeesTransactions)
                .HasForeignKey(d => d.TableNameId)
                .HasConstraintName("FK_Fees_Transactions_Fees_TableName");
        });

        modelBuilder.Entity<FeesTransactionsDetile>(entity =>
        {
            entity.ToTable("Fees_Transactions_Detiles");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Amount)
                .HasComment("المبلغ")
                .HasColumnType("money");
            entity.Property(e => e.FeesActionId).HasColumnName("Fees_Action_ID");
            entity.Property(e => e.FeesTransactionsId).HasColumnName("Fees_Transactions_ID");
            entity.Property(e => e.ItemsId).HasColumnName("Items_ID");
            entity.Property(e => e.SampleDataId).HasColumnName("SampleData_ID");
            entity.Property(e => e.ShiftId).HasColumnName("Shift_ID");
            entity.Property(e => e.TreatmentDataId)
                .HasComment("جاي من جدول Im_Request_TreatmentData عشان لو اكثر من لوط هيبقى كل لوط له id مختلف")
                .HasColumnName("TreatmentData_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.FeesAction).WithMany(p => p.FeesTransactionsDetiles)
                .HasForeignKey(d => d.FeesActionId)
                .HasConstraintName("FK_Fees_Transactions_Detiles_Fees_Action");

            entity.HasOne(d => d.FeesTransactions).WithMany(p => p.FeesTransactionsDetiles)
                .HasForeignKey(d => d.FeesTransactionsId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Fees_Transactions_Detiles_Fees_Transactions");
        });

        modelBuilder.Entity<FeesTransactionsPaymentDetile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Fees_Transactions_Payment_Detailes");

            entity.ToTable("Fees_Transactions_Payment_Detiles");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CardOrGroupNumber)
                .HasMaxLength(50)
                .HasComment("رقم البطاقه(pos) او المجموعه(كاش) علي حسب طريقه الدفع");
            entity.Property(e => e.FeesTransactionsId).HasColumnName("Fees_Transactions_ID");
            entity.Property(e => e.PaymentDate).HasComment("تاريخ الدفع");
            entity.Property(e => e.PosInformationId).HasColumnName("pos_information_id");
            entity.Property(e => e.ReferenceOrCouponNumber)
                .HasMaxLength(50)
                .HasComment("رقم مرجعي او القسيمه");

            entity.HasOne(d => d.FeesTransactions).WithMany(p => p.FeesTransactionsPaymentDetiles)
                .HasForeignKey(d => d.FeesTransactionsId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Fees_Transactions_Payment_Detiles_Fees_Transactions");

            entity.HasOne(d => d.PosInformation).WithMany(p => p.FeesTransactionsPaymentDetiles)
                .HasForeignKey(d => d.PosInformationId)
                .HasConstraintName("FK__Fees_Tran__Fees___1011E5CF");
        });

        modelBuilder.Entity<FeesType>(entity =>
        {
            entity.ToTable("FeesType", tb => tb.HasComment("ثابت - معالجة - نبات - نوباتجية - سحب\r\n"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AccountType)
                .HasDefaultValue(-1)
                .HasColumnName("Account_Type");
            entity.Property(e => e.DisplayOrder).HasColumnName("Display_Order");
            entity.Property(e => e.FullName)
                .HasMaxLength(250)
                .HasColumnName("Full_Name");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name_En");
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<FeesTypeAction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Feer_Type_Action");

            entity.ToTable("Fees_Type_Action", tb => tb.HasComment("انواع الاجراءات"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FeesProcessId).HasColumnName("Fees_process_ID");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name_En");
            entity.Property(e => e.TableName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.FeesProcess).WithMany(p => p.FeesTypeActions)
                .HasForeignKey(d => d.FeesProcessId)
                .HasConstraintName("FK_Feer_Type_Action_Fees_process");
        });

        modelBuilder.Entity<FreeZone>(entity =>
        {
            entity.ToTable("FreeZone");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddressAr).HasColumnName("Address_Ar");
            entity.Property(e => e.AddressEn).HasColumnName("Address_En");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fax).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.GovId).HasColumnName("Gov_ID");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_En");
            entity.Property(e => e.Phone).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.Gov).WithMany(p => p.FreeZones)
                .HasForeignKey(d => d.GovId)
                .HasConstraintName("FK_FreeZone_Governate");
        });

        modelBuilder.Entity<FumigationUnit>(entity =>
        {
            entity.ToTable("FumigationUnit", tb => tb.HasComment("وحدات التبخير التابعة للحجر"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Capacity)
                .HasComment("السعة")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Maintenance).HasComment("حركة الصيانة مرتبط مع الشئون المالية");
            entity.Property(e => e.OutletId).HasColumnName("Outlet_ID");
            entity.Property(e => e.Status).HasComment("0 if work else 1");
            entity.Property(e => e.UnitTypeId).HasColumnName("UnitType_ID");

            entity.HasOne(d => d.Outlet).WithMany(p => p.FumigationUnits)
                .HasForeignKey(d => d.OutletId)
                .HasConstraintName("FK_FumigationUnit_Outlet");

            entity.HasOne(d => d.UnitType).WithMany(p => p.FumigationUnits)
                .HasForeignKey(d => d.UnitTypeId)
                .HasConstraintName("FK_FumigationUnit_UnitType");
        });

        modelBuilder.Entity<GasImportCompany>(entity =>
        {
            entity.ToTable("Gas_ImportCompany", tb => tb.HasComment("شركات استيراد الغاز"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AcceptanceDate).HasComment("تاريخ الموافقة");
            entity.Property(e => e.CompanyId).HasColumnName("Company_ID");
            entity.Property(e => e.GasAmount)
                .HasComment("كمية الغاز المستوردة")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.Company).WithMany(p => p.GasImportCompanies)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_Gas_ImportCompany_Company_National");
        });

        modelBuilder.Entity<GeneralAdmin>(entity =>
        {
            entity.ToTable("General_Admin", tb => tb.HasComment("الإدارة العامة"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddressAr)
                .HasComment("العنوان بالعربية")
                .HasColumnName("Address_Ar");
            entity.Property(e => e.AddressEn)
                .IsUnicode(false)
                .HasComment("العنوان بالانجليزية")
                .HasColumnName("Address_En");
            entity.Property(e => e.AdminId)
                .HasComment("رئيس/مدير الإدارة\r\nfrom HR employee table")
                .HasColumnName("Admin_ID");
            entity.Property(e => e.ArName)
                .HasMaxLength(100)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Ar_Name");
            entity.Property(e => e.EnName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("En_Name");
            entity.Property(e => e.HrSectorNo).HasColumnName("HR_SECTOR_NO");
            entity.Property(e => e.IdOrcael).HasColumnName("ID_Orcael");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<Governate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_LK_CountryCity");

            entity.ToTable("Governate", tb => tb.HasComment("المحافظة"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ArName)
                .HasMaxLength(150)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Ar_Name");
            entity.Property(e => e.EnName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("En_Name");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.ToTable("Group", tb => tb.HasComment("المجموعة الزراعيه"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("Name_En");
            entity.Property(e => e.SecClassId).HasColumnName("SecClass_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.SecClass).WithMany(p => p.Groups)
                .HasForeignKey(d => d.SecClassId)
                .HasConstraintName("FK_Group_SecondaryClassification");
        });

        modelBuilder.Entity<HagrContact>(entity =>
        {
            entity.ToTable("HagrContact");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ContactOwnerId).HasColumnName("ContactOwnerID");
            entity.Property(e => e.ContactTypeId)
                .HasComment("نوع وسيلة الاتصال")
                .HasColumnName("ContactType_ID");
            entity.Property(e => e.OutlitAdmin).HasComment("from systemcode table 5");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
            entity.Property(e => e.Value)
                .HasMaxLength(150)
                .HasComment("الرقم");

            entity.HasOne(d => d.ContactType).WithMany(p => p.HagrContacts)
                .HasForeignKey(d => d.ContactTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HagrContact_ContactType");

            entity.HasOne(d => d.OutlitAdminNavigation).WithMany(p => p.HagrContacts)
                .HasForeignKey(d => d.OutlitAdmin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HagrContact_A_SystemCode");
        });

        modelBuilder.Entity<ImCheckRequest>(entity =>
        {
            entity.ToTable("Im_CheckRequest", tb => tb.HasComment("طلب الفحص الوارد"));

            entity.HasIndex(e => new { e.CheckRequestNumber, e.OutletId }, "IX_Im_CheckRequest_Number_Outlet");

            entity.HasIndex(e => new { e.OutletId, e.UserCreationDate }, "IX_Im_CheckRequest_Outlet_CreationDate");

            entity.HasIndex(e => e.CheckRequestNumber, "UQ_CheckRequest_Number").IsUnique();

            entity.HasIndex(e => new { e.UserCreationDate, e.CheckRequestNumber, e.OutletId, e.IsAccepted, e.Id }, "_dta_index_Im_CheckRequest_15_2006454372__K11_K3_K2_K8_K1");

            entity.HasIndex(e => new { e.Id, e.OutletId }, "_dta_index_Im_CheckRequest_15_2006454372__K1_K2");

            entity.HasIndex(e => e.OutletId, "_dta_index_Im_CheckRequest_15_2006454372__K2");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Amount)
                .HasComment("المبلغ")
                .HasColumnType("money");
            entity.Property(e => e.CheckRequestNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("رقم طلب الفحص")
                .HasColumnName("CheckRequest_Number");
            entity.Property(e => e.CompletionNotes).HasColumnName("Completion_Notes");
            entity.Property(e => e.CompletionRequestDate)
                .HasColumnType("datetime")
                .HasColumnName("Completion_Request_Date");
            entity.Property(e => e.CompletionResponseDate)
                .HasColumnType("datetime")
                .HasColumnName("Completion_Response_Date");
            entity.Property(e => e.CompletionResponseUserId).HasColumnName("Completion_Response_User_Id");
            entity.Property(e => e.CompletionStatus).HasColumnName("Completion_Status");
            entity.Property(e => e.ExportCompany)
                .HasMaxLength(250)
                .HasComment("الشركة المصدرة");
            entity.Property(e => e.ExportCompanyAddress).HasComment("عنوان الشركة المصدرة");
            entity.Property(e => e.ImOperationType)
                .HasComment("نوع إذن الاستراد")
                .HasColumnName("Im_OperationType");
            entity.Property(e => e.IsAcceptedDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("IsAccepted_Date");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsPaid).HasDefaultValue(false);
            entity.Property(e => e.OutletId).HasColumnName("Outlet_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.Outlet).WithMany(p => p.ImCheckRequests)
                .HasForeignKey(d => d.OutletId)
                .HasConstraintName("FK_Im_CheckRequest_Outlet");
        });

        modelBuilder.Entity<ImCheckRequestCustomsMessage>(entity =>
        {
            entity.ToTable("Im_CheckRequest_Customs_Message", tb => tb.HasComment("البيانات الجمركيه"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ArrivalDate)
                .HasComment("تاريخ الوصول ")
                .HasColumnName("Arrival_Date");
            entity.Property(e => e.CertificateNumberEachProduct)
                .HasMaxLength(50)
                .HasComment("رقم الشهادة لكل منتج")
                .HasColumnName("Certificate_Number_Each_Product");
            entity.Property(e => e.CertificationDate)
                .HasComment("تاريخ الشهاده الجمركيه")
                .HasColumnName("Certification_Date");
            entity.Property(e => e.CustomsCertificateNumber)
                .HasMaxLength(50)
                .HasComment("رقم الشهاده الجمركيه")
                .HasColumnName("Customs_Certificate_Number");
            entity.Property(e => e.ImCheckRequestId)
                .HasComment("كود الطلب")
                .HasColumnName("Im_CheckRequest_ID");
            entity.Property(e => e.ImOperationType)
                .HasComment("نوع الطلب")
                .HasColumnName("Im_OperationType");
            entity.Property(e => e.ManifestNumber)
                .HasMaxLength(50)
                .HasColumnName("Manifest_Number");
            entity.Property(e => e.ShipmentDate)
                .HasComment("تاريخ الشحن")
                .HasColumnName("Shipment_Date");
            entity.Property(e => e.ShippingAgencyId).HasColumnName("Shipping_Agency_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ImCheckRequest).WithMany(p => p.ImCheckRequestCustomsMessages)
                .HasForeignKey(d => d.ImCheckRequestId)
                .HasConstraintName("FK_Im_CheckRequest_Customs_Message_Im_CheckRequest");

            entity.HasOne(d => d.ShippingAgency).WithMany(p => p.ImCheckRequestCustomsMessages)
                .HasForeignKey(d => d.ShippingAgencyId)
                .HasConstraintName("FK_Im_CheckRequest_Customs_Message_ShippingAgencies");
        });

        modelBuilder.Entity<ImCheckRequestDataExtra>(entity =>
        {
            entity.ToTable("Im_CheckRequestData_Extra");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ImCheckRequestDataId).HasColumnName("Im_CheckRequest_Data_ID");
            entity.Property(e => e.ImporeterCompanyAddress).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.ImporeterCompanyAddressEn)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("ImporeterCompanyAddress_EN");
            entity.Property(e => e.ImportCompany).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.ImportCompanyEn)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("ImportCompany_EN");
            entity.Property(e => e.OwnerAddress).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.OwnerName).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.RecieverName)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("Reciever_Name");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ImCheckRequestData).WithMany(p => p.ImCheckRequestDataExtras)
                .HasForeignKey(d => d.ImCheckRequestDataId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_CheckRequestData_Extra_Im_CheckRequest_Data");
        });

        modelBuilder.Entity<ImCheckRequestDatum>(entity =>
        {
            entity.ToTable("Im_CheckRequest_Data");

            entity.HasIndex(e => e.ImCheckRequestId, "IX_ImCheckRequestData_Request");

            entity.HasIndex(e => new { e.ImporterId, e.ExportCountryId }, "_dta_index_Im_CheckRequest_Data_15_948406648__K2_K4_3_13");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.DelegateAddress)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.DelegateName)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.ExportCountryId).HasColumnName("ExportCountry_Id");
            entity.Property(e => e.ExportRegionsId).HasColumnName("Export_Regions_ID");
            entity.Property(e => e.GovernateId).HasColumnName("Governate_ID");
            entity.Property(e => e.ImCheckRequestId).HasColumnName("Im_CheckRequest_ID");
            entity.Property(e => e.ImporterId).HasColumnName("Importer_ID");
            entity.Property(e => e.ImporterTypeId).HasColumnName("ImporterType_Id");
            entity.Property(e => e.InternationalTransportationId).HasColumnName("InternationalTransportation_ID");
            entity.Property(e => e.ShipName)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("Ship_Name");
            entity.Property(e => e.ShipmentMeanId).HasColumnName("Shipment_Mean_Id");
            entity.Property(e => e.ShippingCompaniesId).HasColumnName("ShippingCompanies_ID");
            entity.Property(e => e.TransitCountryId)
                .HasComment("دولة العبور")
                .HasColumnName("TransitCountry_Id");
            entity.Property(e => e.TransitRegionsId).HasColumnName("Transit_Regions_ID");
            entity.Property(e => e.TransportMeanId).HasColumnName("Transport_Mean_Id");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ExportCountry).WithMany(p => p.ImCheckRequestData)
                .HasForeignKey(d => d.ExportCountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_CheckRequest_Data_Country");

            entity.HasOne(d => d.ImCheckRequest).WithMany(p => p.ImCheckRequestData)
                .HasForeignKey(d => d.ImCheckRequestId)
                .HasConstraintName("FK_Im_CheckRequest_Data_Im_CheckRequest");

            entity.HasOne(d => d.InternationalTransportation).WithMany(p => p.ImCheckRequestData)
                .HasForeignKey(d => d.InternationalTransportationId)
                .HasConstraintName("FK_Im_CheckRequest_Data_InternationalTransportation");

            entity.HasOne(d => d.ShipmentMean).WithMany(p => p.ImCheckRequestData)
                .HasForeignKey(d => d.ShipmentMeanId)
                .HasConstraintName("FK_Im_CheckRequest_Data_Shipment_Mean");

            entity.HasOne(d => d.ShippingCompanies).WithMany(p => p.ImCheckRequestData)
                .HasForeignKey(d => d.ShippingCompaniesId)
                .HasConstraintName("FK_Im_CheckRequest_Data_ShippingCompanies");

            entity.HasOne(d => d.TransportMean).WithMany(p => p.ImCheckRequestData)
                .HasForeignKey(d => d.TransportMeanId)
                .HasConstraintName("FK_Im_CheckRequest_Data_Transport_Mean");
        });

        modelBuilder.Entity<ImCheckRequestDistribution>(entity =>
        {
            entity.ToTable("Im_CheckRequest_Distribution");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.DateDistribution)
                .HasColumnType("datetime")
                .HasColumnName("Date_Distribution");
            entity.Property(e => e.GrossWeight).HasColumnType("decimal(22, 6)");
            entity.Property(e => e.ImCheckRequestId).HasColumnName("Im_CheckRequest_ID");
            entity.Property(e => e.ImInitiatorId).HasColumnName("Im_Initiator_ID");
            entity.Property(e => e.ImporterId).HasColumnName("Importer_ID");
            entity.Property(e => e.ImporterTypeId).HasColumnName("ImporterType_Id");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ItemCategoryId).HasColumnName("ItemCategory_ID");
            entity.Property(e => e.ItemId).HasColumnName("Item_ID");
            entity.Property(e => e.ItemShortNameId).HasColumnName("Item_ShortName_ID");
            entity.Property(e => e.NetWeight)
                .HasComment("الوزن الصافي")
                .HasColumnType("decimal(22, 6)")
                .HasColumnName("Net_Weight");
            entity.Property(e => e.NumDistribution).HasColumnName("Num_Distribution");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ImCheckRequest).WithMany(p => p.ImCheckRequestDistributions)
                .HasForeignKey(d => d.ImCheckRequestId)
                .HasConstraintName("FK_Im_CheckRequest_Distribution_Im_CheckRequest");
        });

        modelBuilder.Entity<ImCheckRequestFinalResult>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Im_CheckRequest_Items_Final_Position");

            entity.ToTable("Im_CheckRequest_Final_Result", tb => tb.HasComment("الموقف النهائي لطلب الفحص"));

            entity.HasIndex(e => new { e.ImCheckRequestId, e.Id }, "IX_ImCheckRequestFinalResult_Request_Latest").IsDescending(false, true);

            entity.HasIndex(e => e.ImCheckRequestId, "_dta_index_Im_CheckRequest_Final_Result_15_1966070190__K2");

            entity.HasIndex(e => new { e.ImCheckRequestId, e.Id }, "_dta_index_Im_CheckRequest_Final_Result_15_1966070190__K2_K1");

            entity.HasIndex(e => new { e.ImCheckRequestId, e.Id }, "_dta_index_Im_CheckRequest_Final_Result_15_1966070190__K2_K1_3");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ImCheckRequestId)
                .HasComment("جدول طلب الفحص الوارد")
                .HasColumnName("Im_CheckRequest_ID");
            entity.Property(e => e.ImFinalResultId)
                .HasComment("جدول الموقف النهائي")
                .HasColumnName("Im_Final_Result_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ImCheckRequest).WithMany(p => p.ImCheckRequestFinalResults)
                .HasForeignKey(d => d.ImCheckRequestId)
                .HasConstraintName("FK_Im_CheckRequest_Items_Final_Result_Im_CheckRequest");

            entity.HasOne(d => d.ImFinalResult).WithMany(p => p.ImCheckRequestFinalResults)
                .HasForeignKey(d => d.ImFinalResultId)
                .HasConstraintName("FK_Im_CheckRequest_Items_Final_Position_Im_Final_Position");
        });

        modelBuilder.Entity<ImCheckRequestItem>(entity =>
        {
            entity.ToTable("Im_CheckRequest_Items", tb => tb.HasComment("نباتات طلب الفحص الوارد"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AcceptDate).HasColumnName("Accept_Date");
            entity.Property(e => e.AcceptUserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Accept_User_Creation_Date");
            entity.Property(e => e.AcceptUserCreationId).HasColumnName("Accept_User_Creation_Id");
            entity.Property(e => e.AcceptUserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Accept_User_Updation_Date");
            entity.Property(e => e.AcceptUserUpdationId).HasColumnName("Accept_User_Updation_Id");
            entity.Property(e => e.CountryId).HasColumnName("Country_ID");
            entity.Property(e => e.Fees).HasColumnType("money");
            entity.Property(e => e.FeesActual)
                .HasColumnType("money")
                .HasColumnName("Fees_Actual");
            entity.Property(e => e.GrossWeight).HasColumnType("decimal(22, 6)");
            entity.Property(e => e.ImCheckRequsetShippingMethodId).HasColumnName("Im_CheckRequset_Shipping_Method_ID");
            entity.Property(e => e.ImInitiatorId).HasColumnName("Im_Initiator_ID");
            entity.Property(e => e.IsLotDivision).HasColumnName("Is_LotDivision");
            entity.Property(e => e.IsPaid).HasDefaultValue(false);
            entity.Property(e => e.ItemPermissionNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("Item_Permission_Number");
            entity.Property(e => e.ItemShortNameId).HasColumnName("Item_ShortName_ID");
            entity.Property(e => e.NetWeight)
                .HasComment("الوزن الصافي")
                .HasColumnType("decimal(22, 6)")
                .HasColumnName("Net_Weight");
            entity.Property(e => e.OrderText)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("Order_Text");
            entity.Property(e => e.PackageCount).HasColumnName("Package_Count");
            entity.Property(e => e.PackageMaterialId).HasColumnName("Package_Material_ID");
            entity.Property(e => e.PackageTypeId).HasColumnName("Package_Type_ID");
            entity.Property(e => e.PackageWeight)
                .HasColumnType("decimal(22, 6)")
                .HasColumnName("Package_Weight");
            entity.Property(e => e.QualitativeGroupId).HasColumnName("QualitativeGroup_Id");
            entity.Property(e => e.SubPartId).HasColumnName("SubPart_id");
            entity.Property(e => e.UnitsNumber).HasColumnName("Units_Number");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");

            entity.HasOne(d => d.ImCheckRequsetShippingMethod).WithMany(p => p.ImCheckRequestItems)
                .HasForeignKey(d => d.ImCheckRequsetShippingMethodId)
                .HasConstraintName("FK_Im_CheckRequest_Items_IM_CheckRequset_shippingmethod");

            entity.HasOne(d => d.ImInitiator).WithMany(p => p.ImCheckRequestItems)
                .HasForeignKey(d => d.ImInitiatorId)
                .HasConstraintName("FK_Im_CheckRequest_Items_Im_Initiator");
        });

        modelBuilder.Entity<ImCheckRequestItemsLotCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Im_CheckRequest_Items_Category");

            entity.ToTable("Im_CheckRequest_Items_Lot_Category", tb => tb.HasComment("تقسيم لوط وااصناف"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.BasedWeight)
                .HasComment("مش مستخدم")
                .HasColumnType("decimal(22, 6)")
                .HasColumnName("Based_Weight");
            entity.Property(e => e.ContainersTypeId)
                .HasComment("عبوات او بدون")
                .HasColumnName("containers_type_ID");
            entity.Property(e => e.DistinctiveMark)
                .HasMaxLength(250)
                .HasComment("علامة مميزة");
            entity.Property(e => e.GrossWeight)
                .HasComment("اجمالى الوزن القائم لللوطات")
                .HasColumnType("decimal(22, 6)");
            entity.Property(e => e.GrowerNumber)
                .HasMaxLength(50)
                .HasComment("رقم المزرعه من الصادر ,وبعض الحالات من الوارد")
                .HasColumnName("Grower_Number");
            entity.Property(e => e.ImCheckRequestItemsId).HasColumnName("Im_CheckRequest_Items_ID");
            entity.Property(e => e.IsAccepted).HasComment("مقبول = 1 / مرفوض =0");
            entity.Property(e => e.ItemCategoryId).HasColumnName("ItemCategory_ID");
            entity.Property(e => e.LotNumber)
                .HasMaxLength(50)
                .HasComment("رقم اللوط")
                .HasColumnName("Lot_Number");
            entity.Property(e => e.NetWeight)
                .HasComment("الوزن الصافي لللوطات")
                .HasColumnType("decimal(22, 6)")
                .HasColumnName("Net_Weight");
            entity.Property(e => e.NumberWoodenPackage)
                .HasMaxLength(50)
                .HasComment("عدد وحدات التعبئه الخشبيه ")
                .HasColumnName("Number_Wooden_Package");
            entity.Property(e => e.OrderText)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("Order_Text");
            entity.Property(e => e.PackageBasedWeight)
                .HasComment("وزن العبوة القائم")
                .HasColumnType("decimal(22, 6)")
                .HasColumnName("Package_Based_Weight");
            entity.Property(e => e.PackageCount)
                .HasComment("عدد العبوات")
                .HasColumnName("Package_Count");
            entity.Property(e => e.PackageMaterialId)
                .HasComment("مادة العبوة")
                .HasColumnName("Package_Material_ID");
            entity.Property(e => e.PackageNetWeight)
                .HasComment("وزن العبوة الفارغ")
                .HasColumnType("decimal(22, 6)")
                .HasColumnName("Package_Net_Weight");
            entity.Property(e => e.PackageTypeId)
                .HasComment("نوع العبوة")
                .HasColumnName("Package_Type_ID");
            entity.Property(e => e.PackageWeight)
                .HasComment("الوزن العبوه الصافي")
                .HasColumnType("decimal(22, 6)")
                .HasColumnName("Package_Weight");
            entity.Property(e => e.PackagesCount)
                .HasMaxLength(250)
                .HasComment("عدد الطرود");
            entity.Property(e => e.ReasonEntry)
                .HasComment("سبب الدخول")
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("Reason_Entry");
            entity.Property(e => e.RejectReason)
                .HasMaxLength(300)
                .HasComment("اسباب الرفض");
            entity.Property(e => e.ShipName)
                .HasMaxLength(250)
                .HasComment("علامة مميزة");
            entity.Property(e => e.TripDate).HasComment("تاريخ الرحلة");
            entity.Property(e => e.UnitsNumber)
                .HasComment("عدد الوحدات")
                .HasColumnName("Units_Number");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.Waybill)
                .HasMaxLength(100)
                .HasComment("رقم بوليصه الشحن");

            entity.HasOne(d => d.ImCheckRequestItems).WithMany(p => p.ImCheckRequestItemsLotCategories)
                .HasForeignKey(d => d.ImCheckRequestItemsId)
                .HasConstraintName("FK_Im_CheckRequest_Items_Category_Im_CheckRequest_Items");

            entity.HasOne(d => d.ItemCategory).WithMany(p => p.ImCheckRequestItemsLotCategories)
                .HasForeignKey(d => d.ItemCategoryId)
                .HasConstraintName("FK_Im_CheckRequest_Items_Category_ItemCategories");
        });

        modelBuilder.Entity<ImCheckRequestItemsLotResult>(entity =>
        {
            entity.ToTable("Im_CheckRequest_Items_Lot_Result", tb => tb.HasComment("نتيجه اللوط"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ImCheckRequestItemsLotCategoryId).HasColumnName("Im_CheckRequest_Items_Lot_Category_ID");
            entity.Property(e => e.IsStatus)
                .HasComment("الموقف مقبول او مرفوض")
                .HasColumnName("IS_Status");
            entity.Property(e => e.IsStatusCommittee)
                .HasComment("الموقف مقبول او مرفوض")
                .HasColumnName("IS_Status_Committee");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.IsStatusNavigation).WithMany(p => p.ImCheckRequestItemsLotResults)
                .HasForeignKey(d => d.IsStatus)
                .HasConstraintName("FK_Im_CheckRequest_Items_Lot_Result_Im_CheckRequest_Lot_Result_Status");
        });

        modelBuilder.Entity<ImCheckRequestLotResultStatus>(entity =>
        {
            entity.ToTable("Im_CheckRequest_Lot_Result_Status");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CommitteeTypeId).HasColumnName("CommitteeType_ID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsContinue)
                .HasComment("0 عدم استكمال الاعمال\r\nلا يمكن استكمال الاعمال 1")
                .HasColumnName("Is_Continue");
            entity.Property(e => e.NameAr).HasColumnName("Name_AR");
            entity.Property(e => e.NameEn).HasColumnName("Name_En");
        });

        modelBuilder.Entity<ImCheckRequestManafest>(entity =>
        {
            entity.ToTable("Im_CheckRequest_Manafest");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ImCheckRequestId).HasColumnName("Im_CheckRequest_Id");
            entity.Property(e => e.ImManafest).HasColumnName("Im_Manafest");

            entity.HasOne(d => d.ImCheckRequest).WithMany(p => p.ImCheckRequestManafests)
                .HasForeignKey(d => d.ImCheckRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_CheckRequest_Manafest_Im_CheckRequest");

            entity.HasOne(d => d.ImManafestNavigation).WithMany(p => p.ImCheckRequestManafests)
                .HasForeignKey(d => d.ImManafest)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_CheckRequest_Manafest_Im_Manafest");
        });

        modelBuilder.Entity<ImCheckRequestPort>(entity =>
        {
            entity.ToTable("Im_CheckRequest_Port");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ImCheckRequestDataId).HasColumnName("Im_CheckRequest_Data_ID");
            entity.Property(e => e.IsNational).HasComment("دولية ولا لا");
            entity.Property(e => e.PortId)
                .HasComment("رقم الميناء")
                .HasColumnName("Port_ID");
            entity.Property(e => e.PortTypeId)
                .HasComment("نوع المينا بحرى جوى مطار")
                .HasColumnName("Port_Type_ID");
            entity.Property(e => e.ReqPortTypeId)
                .HasComment("ميناء شحن وصور وعبور")
                .HasColumnName("ReqPortType_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<ImCheckRequestRefuseReason>(entity =>
        {
            entity.ToTable("Im_CheckRequest_RefuseReason", tb => tb.HasComment("اسباب رفض الطلب وارد"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ImCheckRequestId).HasColumnName("Im_CheckRequest_Id");
            entity.Property(e => e.RefuseReasonId).HasColumnName("Refuse_Reason_Id");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");

            entity.HasOne(d => d.ImCheckRequest).WithMany(p => p.ImCheckRequestRefuseReasons)
                .HasForeignKey(d => d.ImCheckRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_CheckRequest_RefuseReason_Im_CheckRequest");

            entity.HasOne(d => d.RefuseReason).WithMany(p => p.ImCheckRequestRefuseReasons)
                .HasForeignKey(d => d.RefuseReasonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_CheckRequest_RefuseReason_Refuse_Reason");
        });

        modelBuilder.Entity<ImCheckRequestSampleDataConfirm>(entity =>
        {
            entity.ToTable("Im_CheckRequest_SampleData_Confirm", tb => tb.HasComment("نتيجه سحب عينه للمساعد"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnType("smalldatetime");
            entity.Property(e => e.ImCheckRequestSampleDataId).HasColumnName("Im_CheckRequest_SampleData_ID");
            entity.Property(e => e.IsAccepted).HasDefaultValue(true);
            entity.Property(e => e.Notes).HasMaxLength(500);

            entity.HasOne(d => d.ImCheckRequestSampleData).WithMany(p => p.ImCheckRequestSampleDataConfirms)
                .HasForeignKey(d => d.ImCheckRequestSampleDataId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_CheckRequest_SampleData_Confirm_Im_CheckRequest_SampleData");
        });

        modelBuilder.Entity<ImCheckRequestSampleDatum>(entity =>
        {
            entity.ToTable("Im_CheckRequest_SampleData", tb => tb.HasComment("نتيجه سحب عينه للوارد (admin)"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AdminConfirmation)
                .HasComment("موقف الحجر")
                .HasColumnName("Admin_Confirmation");
            entity.Property(e => e.AdminDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Admin_Date");
            entity.Property(e => e.AdminUser)
                .HasComment("ادمن الحجر")
                .HasColumnName("Admin_User");
            entity.Property(e => e.Amount)
                .HasComment("المبلغ")
                .HasColumnType("money");
            entity.Property(e => e.AnalysisLabTypeId).HasColumnName("AnalysisLabType_ID");
            entity.Property(e => e.FeesActual)
                .HasColumnType("money")
                .HasColumnName("Fees_Actual");
            entity.Property(e => e.ImRequestCommitteeId)
                .HasComment("كود اساسيات اللجنه")
                .HasColumnName("Im_RequestCommittee_ID");
            entity.Property(e => e.ImRequestItemId).HasColumnName("Im_Request_Item_Id");
            entity.Property(e => e.IsAccepted).HasComment("0 if rejected else 1 \r\nموافقه المعمل");
            entity.Property(e => e.IsFromAndroid)
                .HasDefaultValue(false)
                .HasComment("مين رمي row (system or android)")
                .HasColumnName("IS_From_Android");
            entity.Property(e => e.IsPaid).HasDefaultValue(false);
            entity.Property(e => e.IsTotal)
                .HasComment("(0) in the case of all,(1) in the case of the part   في حاله الجزئي او الكلي")
                .HasColumnName("IS_Total");
            entity.Property(e => e.IsTotalAndroid)
                .HasComment("في حاله الفحص لو كلي واتحول الي جزئي")
                .HasColumnName("IS_Total_Android");
            entity.Property(e => e.ItemShortNameId)
                .HasComment("الاسم المختصر ")
                .HasColumnName("Item_ShortName_ID");
            entity.Property(e => e.LotDataId)
                .HasComment("null for the whole request  /  كود بيانات الدفعه")
                .HasColumnName("LotData_ID");
            entity.Property(e => e.NotesAr)
                .HasMaxLength(300)
                .HasComment("ملاحظات الاندريد")
                .HasColumnName("Notes_Ar");
            entity.Property(e => e.NotesEn)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("Notes_En");
            entity.Property(e => e.RejectReasonAr)
                .HasMaxLength(150)
                .HasComment("سبب الرفض للمعمل ar\r\n")
                .HasColumnName("RejectReason_Ar");
            entity.Property(e => e.RejectReasonEn)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("سبب الرفض للمعمل en")
                .HasColumnName("RejectReason_En");
            entity.Property(e => e.SampleBarCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("البار كود")
                .HasColumnName("Sample_BarCode");
            entity.Property(e => e.SampleQuantityUnit).HasMaxLength(10);
            entity.Property(e => e.SampleRatio).HasComment("نسبة اخذ العينة");
            entity.Property(e => e.SampleSize).HasComment("حجم العينة");
            entity.Property(e => e.SylAlkhatimaNumber)
                .HasComment("رقم الختامه والسيل الملاحي")
                .HasColumnName("Syl_ALkhatima_Number");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
            entity.Property(e => e.WithdrawDate).HasComment("تاريخ سحب العينة");

            entity.HasOne(d => d.AnalysisLabType).WithMany(p => p.ImCheckRequestSampleData)
                .HasForeignKey(d => d.AnalysisLabTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_CheckRequest_SampleData_AnalysisLabType");

            entity.HasOne(d => d.ImRequestCommittee).WithMany(p => p.ImCheckRequestSampleData)
                .HasForeignKey(d => d.ImRequestCommitteeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_CheckRequest_SampleData_Im_RequestCommittee");
        });

        modelBuilder.Entity<ImCheckRequestVisa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Im_CheckRequest_Items_Lot_Visa");

            entity.ToTable("Im_CheckRequest_Visa", tb => tb.HasComment("عدد التاشيرات علي طلب الفحص"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ImCheckRequestId)
                .HasComment("جدول طلب الفحص الوارد")
                .HasColumnName("Im_CheckRequest_ID");
            entity.Property(e => e.ImVisaId)
                .HasComment("جدول التاشيره")
                .HasColumnName("Im_Visa_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ImCheckRequest).WithMany(p => p.ImCheckRequestVisas)
                .HasForeignKey(d => d.ImCheckRequestId)
                .HasConstraintName("FK_Im_CheckRequest_Items_Lot_Visa_Im_CheckRequest");

            entity.HasOne(d => d.ImVisa).WithMany(p => p.ImCheckRequestVisas)
                .HasForeignKey(d => d.ImVisaId)
                .HasConstraintName("FK_Im_CheckRequest_Items_Lot_Visa_Im_Visa");
        });

        modelBuilder.Entity<ImCheckRequsetShippingMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_IM_CheckRequset_shippingmethod");

            entity.ToTable("Im_CheckRequset_Shipping_Method", tb => tb.HasComment("اساليب الشحن لطلب الفحص الوارد"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ContainerNumber)
                .HasMaxLength(50)
                .HasComment("رقم الحاوية");
            entity.Property(e => e.ContainersId)
                .HasComment("حاوية او صب")
                .HasColumnName("containers_ID");
            entity.Property(e => e.ContainersTypeId)
                .HasComment("عبوات او بدون")
                .HasColumnName("containers_type_ID");
            entity.Property(e => e.ImCheckRequestId).HasColumnName("Im_CheckRequest_ID");
            entity.Property(e => e.NavigationalNumber)
                .HasMaxLength(50)
                .HasComment("رقم السيل الملاحي");
            entity.Property(e => e.ShipholdNumber)
                .HasMaxLength(50)
                .HasComment("رقم عنبر السفينة");
            entity.Property(e => e.TotalWeight)
                .HasColumnType("decimal(22, 6)")
                .HasColumnName("Total_Weight");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");

            entity.HasOne(d => d.ImCheckRequest).WithMany(p => p.ImCheckRequsetShippingMethods)
                .HasForeignKey(d => d.ImCheckRequestId)
                .HasConstraintName("FK_IM_CheckRequset_shippingmethod_Im_CheckRequest");
        });

        modelBuilder.Entity<ImChooseConstrain>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Im_Constrain_chooes");

            entity.ToTable("Im_choose_Constrain ");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ImConstrainInitiatorTextId).HasColumnName("Im_Constrain_Initiator_Text_Id");
            entity.Property(e => e.ImConstrainTypeId).HasColumnName("Im_Constrain_Type_Id");
            entity.Property(e => e.ImConstrainsSpecialId).HasColumnName("Im_Constrains_Special_Id");

            entity.HasOne(d => d.ImConstrainInitiatorText).WithMany(p => p.ImChooseConstrains)
                .HasForeignKey(d => d.ImConstrainInitiatorTextId)
                .HasConstraintName("FK_Im_Constrain_chooes_Im_Constrain_Initiator_Text");

            entity.HasOne(d => d.ImConstrainType).WithMany(p => p.ImChooseConstrains)
                .HasForeignKey(d => d.ImConstrainTypeId)
                .HasConstraintName("FK_Im_Constrain_chooes_Im_Constrain_Type");

            entity.HasOne(d => d.ImConstrainsSpecial).WithMany(p => p.ImChooseConstrains)
                .HasForeignKey(d => d.ImConstrainsSpecialId)
                .HasConstraintName("FK_Im_Constrain_chooes_Im_Constrains_Special");
        });

        modelBuilder.Entity<ImCommitteeCheckLocation>(entity =>
        {
            entity.ToTable("Im_CommitteeCheckLocation", tb => tb.HasComment("أماكن الفحص التي يحددها المنفذ"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name_En");
        });

        modelBuilder.Entity<ImCommitteeCustodyPlace>(entity =>
        {
            entity.ToTable("Im_Committee_CustodyPlace", tb => tb.HasComment("لجنة معاينة مكان التحفظ"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CheckDate)
                .HasComment("تاريخ الفحص")
                .HasColumnName("Check_Date");
            entity.Property(e => e.EndTime).HasComment("انتهاء ساعة الفحص");
            entity.Property(e => e.ImCustodyPlaceId).HasColumnName("Im_CustodyPlace_Id");
            entity.Property(e => e.IsApproved).HasComment("0 if exporter doesn't accept else 1");
            entity.Property(e => e.IsPackage).HasComment("هل حاوية أم لا");
            entity.Property(e => e.Quantity).HasComment("العدد");
            entity.Property(e => e.StartTime).HasComment(" بداية ساعة الفحص ");
            entity.Property(e => e.Status).HasComment("0 if not done, 1 if investigation is done");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
            entity.Property(e => e.Weight).HasComment("الوزن");

            entity.HasOne(d => d.ImCustodyPlace).WithMany(p => p.ImCommitteeCustodyPlaces)
                .HasForeignKey(d => d.ImCustodyPlaceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_Committee_CustodyPlace_Im_CustodyPlace");
        });

        modelBuilder.Entity<ImCommitteeResult>(entity =>
        {
            entity.ToTable("Im_CommitteeResult", tb => tb.HasComment("النتيجه"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AdminFinalResultNote)
                .HasComment("Admin Note")
                .HasColumnName("AdminFinalResult_Note");
            entity.Property(e => e.CommitteeId)
                .HasComment("كود اساسيات اللجنه")
                .HasColumnName("Committee_ID");
            entity.Property(e => e.CommitteeResultTypeId).HasColumnName("CommitteeResultType_ID");
            entity.Property(e => e.Date).HasColumnType("smalldatetime");
            entity.Property(e => e.ImRequestItemId).HasColumnName("Im_Request_Item_Id");
            entity.Property(e => e.IsAdminResult).HasComment("null->exporter not take action 0 if exporter doesn't accept else 1");
            entity.Property(e => e.IsTotal)
                .HasComment("(0) in the case of all,(1) in the case of the part   في حاله الجزئي او الكلي")
                .HasColumnName("IS_Total");
            entity.Property(e => e.IsTotalAndroid)
                .HasComment("في حاله الفحص لو كلي واتحول الي جزئي")
                .HasColumnName("IS_Total_Android");
            entity.Property(e => e.ItemShortNameId)
                .HasComment("الاسم المختصر")
                .HasColumnName("Item_ShortName_ID");
            entity.Property(e => e.LotDataId)
                .HasComment("null for the whole request  /  كود بيانات الدفعه")
                .HasColumnName("LotData_ID");
            entity.Property(e => e.QuantitySize).HasComment("العدد");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
            entity.Property(e => e.Weight).HasComment("الوزن");

            entity.HasOne(d => d.Committee).WithMany(p => p.ImCommitteeResults)
                .HasForeignKey(d => d.CommitteeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_CommitteeResult_Im_RequestCommittee");

            entity.HasOne(d => d.CommitteeResultType).WithMany(p => p.ImCommitteeResults)
                .HasForeignKey(d => d.CommitteeResultTypeId)
                .HasConstraintName("FK_Im_CommitteeResult_CommitteeResultType");

            entity.HasOne(d => d.ItemShortName).WithMany(p => p.ImCommitteeResults)
                .HasForeignKey(d => d.ItemShortNameId)
                .HasConstraintName("FK_Im_CommitteeResult_Item_ShortName");
        });

        modelBuilder.Entity<ImCommitteeResultConfirm>(entity =>
        {
            entity.ToTable("Im_CommitteeResult_Confirm", tb => tb.HasComment("راي المساعد"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnType("smalldatetime");
            entity.Property(e => e.ImCommitteeResultId).HasColumnName("Im_CommitteeResult_ID");
            entity.Property(e => e.IsAccepted).HasDefaultValue(true);

            entity.HasOne(d => d.ImCommitteeResult).WithMany(p => p.ImCommitteeResultConfirms)
                .HasForeignKey(d => d.ImCommitteeResultId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_CommitteeResult_Confirm_Im_CommitteeResult");
        });

        modelBuilder.Entity<ImCommitteeResultInfection>(entity =>
        {
            entity.ToTable("Im_CommitteeResult_Infection", tb => tb.HasComment("الاصابه للفحص"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ImCommitteeResultId).HasColumnName("Im_CommitteeResult_ID");
            entity.Property(e => e.ItemId).HasColumnName("Item_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ImCommitteeResult).WithMany(p => p.ImCommitteeResultInfections)
                .HasForeignKey(d => d.ImCommitteeResultId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_CommitteeResult_Infection_Im_CommitteeResult");

            entity.HasOne(d => d.Item).WithMany(p => p.ImCommitteeResultInfections)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_CommitteeResult_Infection_Item");
        });

        modelBuilder.Entity<ImConstrainInitiatorText>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Im_Constrain_Text");

            entity.ToTable("Im_Constrain_Initiator_Text");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ConstrainTextId).HasColumnName("ConstrainText_ID");
            entity.Property(e => e.GroupId).HasColumnName("Group_ID");
            entity.Property(e => e.ImInitiatorId).HasColumnName("Im_Initiator_ID");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasComment("");
            entity.Property(e => e.IsActive1)
                .HasDefaultValue(true)
                .HasComment("");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ConstrainText).WithMany(p => p.ImConstrainInitiatorTexts)
                .HasForeignKey(d => d.ConstrainTextId)
                .HasConstraintName("FK_Im_Constrain_Text_Im_CountryConstrain_Text");

            entity.HasOne(d => d.ImInitiator).WithMany(p => p.ImConstrainInitiatorTexts)
                .HasForeignKey(d => d.ImInitiatorId)
                .HasConstraintName("FK_Im_Constrain_Text_Im_Initiator");
        });

        modelBuilder.Entity<ImConstrainType>(entity =>
        {
            entity.ToTable("Im_Constrain_Type", tb => tb.HasComment("انواع الاشتراطات"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ArName)
                .HasMaxLength(150)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Ar_Name");
            entity.Property(e => e.EnName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("En_Name");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasComment("مفعل");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<ImConstrainsSpecial>(entity =>
        {
            entity.ToTable("Im_Constrains_Special");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ConstrainTextAr).HasColumnName("ConstrainText_Ar");
            entity.Property(e => e.ConstrainTextEn)
                .IsUnicode(false)
                .HasColumnName("ConstrainText_En");
            entity.Property(e => e.ImPermissionRequestId).HasColumnName("Im_PermissionRequest_ID");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasComment("");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<ImCountryConstrainArrivalPort>(entity =>
        {
            entity.ToTable("Im_CountryConstrain_ArrivalPort", tb => tb.HasComment("موانى تحديد ميناء وصول معين"));

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.IdQualitativeGroup).HasColumnName("Id_QualitativeGroup");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasComment("");
            entity.Property(e => e.ItemShortNameId).HasColumnName("Item_ShortName_ID");
            entity.Property(e => e.PortNationalId).HasColumnName("Port_National_Id");
            entity.Property(e => e.PortTypeId).HasColumnName("Port_Type_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");

            entity.HasOne(d => d.IdQualitativeGroupNavigation).WithMany(p => p.ImCountryConstrainArrivalPorts)
                .HasForeignKey(d => d.IdQualitativeGroup)
                .HasConstraintName("FK_Im_CountryConstrain_ArrivalPort_QualitativeGroup");

            entity.HasOne(d => d.ItemShortName).WithMany(p => p.ImCountryConstrainArrivalPorts)
                .HasForeignKey(d => d.ItemShortNameId)
                .HasConstraintName("FK_Im_CountryConstrain_ArrivalPort_Plant_ShortName");

            entity.HasOne(d => d.PortNational).WithMany(p => p.ImCountryConstrainArrivalPorts)
                .HasForeignKey(d => d.PortNationalId)
                .HasConstraintName("FK_Im_CountryConstrain_ArrivalPort_PortNational");
        });

        modelBuilder.Entity<ImCountryConstrainText>(entity =>
        {
            entity.ToTable("Im_CountryConstrain_Text");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ConstrainTextAr).HasColumnName("ConstrainText_Ar");
            entity.Property(e => e.ConstrainTextEn)
                .IsUnicode(false)
                .HasColumnName("ConstrainText_En");
            entity.Property(e => e.ImConstrainTypeId).HasColumnName("Im_Constrain_Type_ID");
            entity.Property(e => e.InSideCertificateAr).HasColumnName("InSide_Certificate_Ar");
            entity.Property(e => e.InSideCertificateEn)
                .IsUnicode(false)
                .HasColumnName("InSide_Certificate_En");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasComment("");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ImConstrainType).WithMany(p => p.ImCountryConstrainTexts)
                .HasForeignKey(d => d.ImConstrainTypeId)
                .HasConstraintName("FK_Im_CountryConstrain_Text_Im_Constrain_Type");
        });

        modelBuilder.Entity<ImCustodyPlace>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Im_CustodyPlace_1");

            entity.ToTable("Im_CustodyPlace", tb => tb.HasComment("اماكن التحفظ"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Address).IsUnicode(false);
            entity.Property(e => e.ArDesc)
                .HasComment("الوصف عربى")
                .HasColumnName("Ar_Desc");
            entity.Property(e => e.CenterId).HasColumnName("Center_Id");
            entity.Property(e => e.DateStored)
                .HasComment("كمية/تاريخ")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.EnDesc)
                .IsUnicode(false)
                .HasComment("الوصف انجليزى")
                .HasColumnName("En_Desc");
            entity.Property(e => e.ImCustodyPlaceType)
                .HasComment("مخزن/ساحة")
                .HasColumnName("Im_CustodyPlaceType");
            entity.Property(e => e.IsApproved)
                .HasDefaultValue(false)
                .HasComment("0 if exporter doesn't accept else 1");
            entity.Property(e => e.NationalId)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("NationalID");
            entity.Property(e => e.OwnerName)
                .IsUnicode(false)
                .HasColumnName("Owner_Name");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Quantity).HasComment("الكمية المخزنة/التاريخ");
            entity.Property(e => e.Status)
                .HasDefaultValue(false)
                .HasComment("0 if not done, 1 if investigation is done");
            entity.Property(e => e.StorageCapacity).HasColumnName("Storage_capacity");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ImCustodyPlaceTypeNavigation).WithMany(p => p.ImCustodyPlaces)
                .HasForeignKey(d => d.ImCustodyPlaceType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_CustodyPlace_Im_CustodyPlaceType");
        });

        modelBuilder.Entity<ImCustodyPlaceCheckRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Im_CustodyPlace");

            entity.ToTable("Im_CustodyPlace_CheckRequest", tb => tb.HasComment("اماكن التحفظ للطلب"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ImCheckRequestId)
                .HasComment("رقم اذن الاستيراد")
                .HasColumnName("Im_CheckRequest_ID");
            entity.Property(e => e.ImCustodyPlaceId).HasColumnName("Im_CustodyPlace_ID");
            entity.Property(e => e.IsApproved)
                .HasDefaultValue(false)
                .HasComment("0 if exporter doesn't accept else 1");
            entity.Property(e => e.StationId)
                .HasComment("المحطة")
                .HasColumnName("Station_ID");
            entity.Property(e => e.Status)
                .HasDefaultValue(false)
                .HasComment("0 if not done, 1 if investigation is done");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ImCheckRequest).WithMany(p => p.ImCustodyPlaceCheckRequests)
                .HasForeignKey(d => d.ImCheckRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_CustodyPlace_Im_CheckRequest");

            entity.HasOne(d => d.ImCustodyPlace).WithMany(p => p.ImCustodyPlaceCheckRequests)
                .HasForeignKey(d => d.ImCustodyPlaceId)
                .HasConstraintName("FK_Im_CustodyPlace_CheckRequest_Im_CustodyPlace");

            entity.HasOne(d => d.Station).WithMany(p => p.ImCustodyPlaceCheckRequests)
                .HasForeignKey(d => d.StationId)
                .HasConstraintName("FK_Im_CustodyPlace_CheckRequest_Station");
        });

        modelBuilder.Entity<ImCustodyPlaceType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CustodyPlace");

            entity.ToTable("Im_CustodyPlaceType", tb => tb.HasComment("نوع مكان التحفظ"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name_En");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<ImExecution>(entity =>
        {
            entity.ToTable("Im_Execution", tb => tb.HasComment("لجنة الاعدام"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ExecutionFile)
                .HasMaxLength(8000)
                .IsFixedLength()
                .HasColumnName("Execution_File");
            entity.Property(e => e.ExecutionMethod)
                .HasMaxLength(250)
                .HasColumnName("Execution_Method");
            entity.Property(e => e.ExecutionPlace)
                .HasMaxLength(250)
                .HasColumnName("Execution_Place");
            entity.Property(e => e.ImRequestCommitteeId).HasColumnName("Im_RequestCommittee_Id");

            entity.HasOne(d => d.ImRequestCommittee).WithMany(p => p.ImExecutions)
                .HasForeignKey(d => d.ImRequestCommitteeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_Execution_Im_RequestCommittee");
        });

        modelBuilder.Entity<ImExecutionItem>(entity =>
        {
            entity.ToTable("Im_Execution_Items", tb => tb.HasComment("عناصر لجنة الاعدام"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.GrossWeight).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ImCheckRequestItemId).HasColumnName("Im_CheckRequest_Item_ID");
            entity.Property(e => e.ImCheckRequestItemsLotCategoryId).HasColumnName("Im_CheckRequest_Items_Lot_Category_ID");
            entity.Property(e => e.ImExecutionId).HasColumnName("Im_Execution_Id");

            entity.HasOne(d => d.ImCheckRequestItem).WithMany(p => p.ImExecutionItems)
                .HasForeignKey(d => d.ImCheckRequestItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Im_Execut__Im_Ch__7B48A5B7");

            entity.HasOne(d => d.ImCheckRequestItemsLotCategory).WithMany(p => p.ImExecutionItems)
                .HasForeignKey(d => d.ImCheckRequestItemsLotCategoryId)
                .HasConstraintName("FK__Im_Execut__Im_Ch__7C3CC9F0");

            entity.HasOne(d => d.ImExecution).WithMany(p => p.ImExecutionItems)
                .HasForeignKey(d => d.ImExecutionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_Execution_Items_Im_Execution");
        });

        modelBuilder.Entity<ImFinalResult>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Im_Final_Position");

            entity.ToTable("Im_Final_Result", tb => tb.HasComment("الموقف النهائي لطلب الفحص"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ArName)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Ar_Name");
            entity.Property(e => e.EnName)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("En_Name");
            entity.Property(e => e.IsActive).HasComment("الطلب فعال ام لا");
            entity.Property(e => e.Status).HasComment("تم ايقاف الطلب ام لا\r\n0 = مرفوض\r\n1 = مقبول");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<ImFumigation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Im_Fumig__3214EC27511DC584");

            entity.ToTable("Im_Fumigation");

            entity.HasIndex(e => e.LotResultId, "UX_Im_Fumigation_Lot_Result_Active")
                .IsUnique()
                .HasFilter("([Lot_Result_ID] IS NOT NULL AND [User_Deletion_Id] IS NULL AND [Source_Distribution_Result_ID] IS NULL)");

            entity.HasIndex(e => e.SourceDistributionResultId, "UX_Im_Fumigation_SourceDistributionResult")
                .IsUnique()
                .HasFilter("([Source_Distribution_Result_ID] IS NOT NULL AND [User_Deletion_Id] IS NULL)");

            entity.Property(e => e.Id)
                .HasComment("المعرف الفريد لطلب التطهير")
                .HasColumnName("ID");
            entity.Property(e => e.ApprovalStatus)
                .HasDefaultValue((short)1)
                .HasComment("حالة الطلب: 1 موافقة، 2 رفض، 3 إعادة علاج");
            entity.Property(e => e.Attachments)
                .HasMaxLength(1000)
                .HasComment("مسار أو قائمة المرفقات الخاصة بالطلب");
            entity.Property(e => e.CommitteeId)
                .HasComment("ربط بلجنة الفحص Im_RequestCommittee")
                .HasColumnName("Committee_Id");
            entity.Property(e => e.CustomsMessageId)
                .HasComment("ربط بالشهادة الجمركية Im_CheckRequest_Customs_Message")
                .HasColumnName("Customs_Message_Id");
            entity.Property(e => e.FinalLotResultId).HasColumnName("Final_Lot_Result_ID");
            entity.Property(e => e.InspectionRequestAction).HasMaxLength(1000);
            entity.Property(e => e.InspectionRequestHoldReason).HasMaxLength(1000);
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasComment("يحدد هل السجل فعال أم محذوف منطقيًا");
            entity.Property(e => e.LotCategoryId).HasColumnName("Lot_Category_ID");
            entity.Property(e => e.LotResultId).HasColumnName("Lot_Result_ID");
            entity.Property(e => e.Notes).HasMaxLength(1000);
            entity.Property(e => e.PoliciesCount).HasComment("عدد بوالص الشحنة");
            entity.Property(e => e.PortId)
                .HasComment("ربط بميناء التطهير PortNational")
                .HasColumnName("Port_Id");
            entity.Property(e => e.ReceivedQuantity)
                .HasComment("الكمية المستلمة بعد التطهير")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RequestId)
                .HasComment("ربط بطلب الفحص Im_CheckRequest")
                .HasColumnName("Request_Id");
            entity.Property(e => e.ReservationReason)
                .HasMaxLength(1000)
                .HasComment("سبب التحفظ عند الرفض أو إعادة العلاج");
            entity.Property(e => e.SourceDistributionResultId).HasColumnName("Source_Distribution_Result_ID");
            entity.Property(e => e.SourceResultStatus).HasColumnName("Source_ResultStatus");
            entity.Property(e => e.SourceSupervisorUserId).HasColumnName("Source_Supervisor_User_ID");
            entity.Property(e => e.TreatmentAddress)
                .HasMaxLength(500)
                .HasComment("العنوان التفصيلي لمكان العلاج");
            entity.Property(e => e.TreatmentDataId).HasColumnName("TreatmentData_ID");
            entity.Property(e => e.TreatmentLocation)
                .HasMaxLength(250)
                .HasComment("مكان إجراء عملية العلاج");
            entity.Property(e => e.UserCreationDate)
                .HasComment("تاريخ إنشاء السجل")
                .HasColumnType("datetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId)
                .HasComment("معرف المستخدم الذي أنشأ السجل")
                .HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasComment("تاريخ حذف السجل")
                .HasColumnType("datetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId)
                .HasComment("معرف المستخدم الذي حذف السجل")
                .HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasComment("تاريخ آخر تعديل على السجل")
                .HasColumnType("datetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId)
                .HasComment("معرف المستخدم الذي عدّل السجل آخر مرة")
                .HasColumnName("User_Updation_Id");
            entity.Property(e => e.WasteQuantity)
                .HasComment("كمية المخلفات الناتجة عن التطهير")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Weight)
                .HasComment("وزن الشحنة الخاضعة للتطهير")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.WeightUnit).HasMaxLength(50);

            entity.HasOne(d => d.Committee).WithMany(p => p.ImFumigations)
                .HasForeignKey(d => d.CommitteeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_Fumigation_Im_RequestCommittee");

            entity.HasOne(d => d.CustomsMessage).WithMany(p => p.ImFumigations)
                .HasForeignKey(d => d.CustomsMessageId)
                .HasConstraintName("FK_Im_Fumigation_Customs_Message");

            entity.HasOne(d => d.LotCategory).WithMany(p => p.ImFumigations)
                .HasForeignKey(d => d.LotCategoryId)
                .HasConstraintName("FK_Im_Fumigation_Lot_Category");

            entity.HasOne(d => d.LotResult).WithOne(p => p.ImFumigation)
                .HasForeignKey<ImFumigation>(d => d.LotResultId)
                .HasConstraintName("FK_Im_Fumigation_Lot_Result");

            entity.HasOne(d => d.Port).WithMany(p => p.ImFumigations)
                .HasForeignKey(d => d.PortId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_Fumigation_PortNational");

            entity.HasOne(d => d.Request).WithMany(p => p.ImFumigations)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_Fumigation_Im_CheckRequest");

            entity.HasOne(d => d.TreatmentData).WithMany(p => p.ImFumigations)
                .HasForeignKey(d => d.TreatmentDataId)
                .HasConstraintName("FK_Im_Fumigation_Im_Request_TreatmentData");
        });

        modelBuilder.Entity<ImFumigationDistribution>(entity =>
        {
            entity.ToTable("Im_Fumigation_Distribution");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(NEXT VALUE FOR [dbo].[Im_Fumigation_Distribution_SEQ])")
                .HasColumnName("ID");
            entity.Property(e => e.AssignedQuantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Attachments).HasMaxLength(1000);
            entity.Property(e => e.FumigationId).HasColumnName("Fumigation_ID");
            entity.Property(e => e.InspectionRequestAction).HasMaxLength(1000);
            entity.Property(e => e.InspectionRequestCount).HasMaxLength(100);
            entity.Property(e => e.InspectionRequestCouponNumber).HasMaxLength(100);
            entity.Property(e => e.InspectionRequestCustomsCertificate).HasMaxLength(100);
            entity.Property(e => e.InspectionRequestFacilityAddress).HasMaxLength(500);
            entity.Property(e => e.InspectionRequestFacilityName).HasMaxLength(250);
            entity.Property(e => e.InspectionRequestHoldReason).HasMaxLength(1000);
            entity.Property(e => e.InspectionRequestImporterName).HasMaxLength(250);
            entity.Property(e => e.InspectionRequestItem).HasMaxLength(250);
            entity.Property(e => e.InspectionRequestNotes).HasMaxLength(1000);
            entity.Property(e => e.InspectionRequestOrigin).HasMaxLength(250);
            entity.Property(e => e.InspectionRequestPoliciesCount).HasMaxLength(100);
            entity.Property(e => e.InspectionRequestPolicyNumbers).HasMaxLength(1000);
            entity.Property(e => e.InspectionRequestVesselTrip).HasMaxLength(250);
            entity.Property(e => e.InspectionRequestWeight).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Notes).HasMaxLength(1000);
            entity.Property(e => e.OutletId).HasColumnName("Outlet_ID");
            entity.Property(e => e.PortId).HasColumnName("Port_ID");
            entity.Property(e => e.QuantityUnit).HasMaxLength(50);
            entity.Property(e => e.RedistributedToId).HasColumnName("RedistributedTo_ID");
            entity.Property(e => e.Status).HasDefaultValue((short)1);
            entity.Property(e => e.SupervisorUserId).HasColumnName("Supervisor_User_ID");
            entity.Property(e => e.TreatmentAddress).HasMaxLength(500);
            entity.Property(e => e.TreatmentLocation).HasMaxLength(250);
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("datetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("datetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("datetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<ImFumigationDistributionInspection>(entity =>
        {
            entity.ToTable("Im_Fumigation_Distribution_Inspection");

            entity.HasIndex(e => e.DistributionId, "UX_Im_Fumigation_Distribution_Inspection_Final")
                .IsUnique()
                .HasFilter("([IsFinalInspection]=(1) AND [User_Deletion_Id] IS NULL)");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(NEXT VALUE FOR [dbo].[Im_Fumigation_Distribution_Inspection_SEQ])")
                .HasColumnName("ID");
            entity.Property(e => e.Attachments).HasMaxLength(1000);
            entity.Property(e => e.DistributionId).HasColumnName("Distribution_ID");
            entity.Property(e => e.InspectionNotes).HasMaxLength(1000);
            entity.Property(e => e.IsFinalInspection).HasDefaultValue(true);
            entity.Property(e => e.RejectionReason).HasMaxLength(1000);
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("datetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("datetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("datetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.Distribution).WithOne(p => p.ImFumigationDistributionInspection)
                .HasForeignKey<ImFumigationDistributionInspection>(d => d.DistributionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_Fumigation_Distribution_Inspection_Distribution");
        });

        modelBuilder.Entity<ImFumigationDistributionMessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Im_Fumig__3214EC27780FD068");

            entity.ToTable("Im_Fumigation_Distribution_Message");

            entity.HasIndex(e => new { e.DistributionId, e.Id }, "IX_FumigationMessage_Distribution");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.DistributionId).HasColumnName("Distribution_ID");
            entity.Property(e => e.MessageText).HasMaxLength(2000);

            entity.HasOne(d => d.Distribution).WithMany(p => p.ImFumigationDistributionMessages)
                .HasForeignKey(d => d.DistributionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Im_Fumiga__Distr__454B1A77");
        });

        modelBuilder.Entity<ImFumigationDistributionMessageRead>(entity =>
        {
            entity.HasKey(e => new { e.DistributionId, e.UserId }).HasName("PK_FumigationMessageRead");

            entity.ToTable("Im_Fumigation_Distribution_Message_Read");

            entity.Property(e => e.DistributionId).HasColumnName("Distribution_ID");
            entity.Property(e => e.ReadAt).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.Distribution).WithMany(p => p.ImFumigationDistributionMessageReads)
                .HasForeignKey(d => d.DistributionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Im_Fumiga__Distr__4B03F3CD");
        });

        modelBuilder.Entity<ImFumigationDistributionResult>(entity =>
        {
            entity.ToTable("Im_Fumigation_Distribution_Result");

            entity.HasIndex(e => e.DistributionId, "IX_Im_Fumigation_Distribution_Result_Distribution").HasFilter("([User_Deletion_Id] IS NULL)");

            entity.HasIndex(e => e.DistributionId, "UX_Im_Fumigation_Distribution_Result_Final")
                .IsUnique()
                .HasFilter("([IsFinalResult]=(1) AND [User_Deletion_Id] IS NULL)");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(NEXT VALUE FOR [dbo].[Im_Fumigation_Distribution_Result_SEQ])")
                .HasColumnName("ID");
            entity.Property(e => e.Attachments).HasMaxLength(1000);
            entity.Property(e => e.DistributionId).HasColumnName("Distribution_ID");
            entity.Property(e => e.ReceivedQuantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.ReservationReason).HasMaxLength(1000);
            entity.Property(e => e.ResultNotes).HasMaxLength(1000);
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("datetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("datetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("datetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
            entity.Property(e => e.WasteQuantity).HasColumnType("decimal(18, 3)");

            entity.HasOne(d => d.Distribution).WithOne(p => p.ImFumigationDistributionResult)
                .HasForeignKey<ImFumigationDistributionResult>(d => d.DistributionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_Fumigation_Distribution_Result_Distribution");
        });

        modelBuilder.Entity<ImFumigationReleaseRequest>(entity =>
        {
            entity.ToTable("Im_Fumigation_Release_Request");

            entity.HasIndex(e => new { e.FumigationId, e.ReleaseRequestNumber }, "UX_Im_Fumigation_Release_Request_Number")
                .IsUnique()
                .HasFilter("([User_Deletion_Id] IS NULL)");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AttachmentNumber).HasMaxLength(100);
            entity.Property(e => e.Attachments).HasMaxLength(1000);
            entity.Property(e => e.FumigationId).HasColumnName("Fumigation_ID");
            entity.Property(e => e.PreviouslyReleasedQuantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.QuantityUnit).HasMaxLength(50);
            entity.Property(e => e.RejectedQuantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.ReleaseLocation).HasMaxLength(500);
            entity.Property(e => e.ReleaseRequestNumber).HasMaxLength(100);
            entity.Property(e => e.ReleasedQuantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.RemainingQuantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.StakeholderName).HasMaxLength(250);
            entity.Property(e => e.TotalQuantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.UserCreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("datetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("datetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.Fumigation).WithMany(p => p.ImFumigationReleaseRequests)
                .HasForeignKey(d => d.FumigationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_Fumigation_Release_Request_Im_Fumigation");
        });

        modelBuilder.Entity<ImInitiator>(entity =>
        {
            entity.ToTable("Im_Initiator", tb => tb.HasComment("المناشىء"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CountryId).HasColumnName("Country_Id");
            entity.Property(e => e.ForbiddenReason).HasMaxLength(150);
            entity.Property(e => e.InitiatorStatus)
                .HasComment("حالة المنشأ\r\nfrom systemcode 16\r\n")
                .HasColumnName("Initiator_Status");
            entity.Property(e => e.IsActive).HasComment("");
            entity.Property(e => e.ItemShortNameId).HasColumnName("Item_ShortName_ID");
            entity.Property(e => e.QualitativeGroupId)
                .HasComment("المجموعة النوعية")
                .HasColumnName("QualitativeGroup_Id");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.Country).WithMany(p => p.ImInitiators)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_Im_Initiator_Country");

            entity.HasOne(d => d.ItemShortName).WithMany(p => p.ImInitiators)
                .HasForeignKey(d => d.ItemShortNameId)
                .HasConstraintName("FK_Im_Initiator_Plant_ShortName");
        });

        modelBuilder.Entity<ImItemsLotDivision>(entity =>
        {
            entity.ToTable("Im_ItemsLotDivision", tb => tb.HasComment("تفاصيل اللوط"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ContainerNumber)
                .HasMaxLength(50)
                .HasComment("رقم الحاوية")
                .HasColumnName("Container_Number");
            entity.Property(e => e.FarmId).HasColumnName("Farm_ID");
            entity.Property(e => e.GrossWeight)
                .HasComment("الوزن القائم")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Gross_Weight");
            entity.Property(e => e.ImPermissionItemsId).HasColumnName("Im_PermissionItems_ID");
            entity.Property(e => e.IsAccepted).HasComment("مقبول = 1 / مرفوض =0");
            entity.Property(e => e.LotNumber)
                .HasMaxLength(50)
                .HasComment("رقم اللوط")
                .HasColumnName("Lot_Number");
            entity.Property(e => e.NavigationalFluidNumber)
                .HasMaxLength(50)
                .HasComment("رقم السيل الملاحي")
                .HasColumnName("NavigationalFluid_Number");
            entity.Property(e => e.NetWeight)
                .HasComment("الوزن الصافي")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Net_Weight");
            entity.Property(e => e.PackageCount)
                .HasComment("عدد العبوات")
                .HasColumnName("Package_Count");
            entity.Property(e => e.PackageMaterialId)
                .HasComment("مادة العبوة")
                .HasColumnName("Package_Material_ID");
            entity.Property(e => e.PackageTypeId)
                .HasComment("نوع العبوة")
                .HasColumnName("Package_Type_ID");
            entity.Property(e => e.PackageWeight)
                .HasComment("وزن العبوة")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Package_Weight");
            entity.Property(e => e.RejectReason).HasMaxLength(300);
            entity.Property(e => e.ShipmentPolicyNumber)
                .HasMaxLength(50)
                .HasComment("رقم بوليصة الشحن")
                .HasColumnName("ShipmentPolicy_Number");

            entity.HasOne(d => d.ImPermissionItems).WithMany(p => p.ImItemsLotDivisions)
                .HasForeignKey(d => d.ImPermissionItemsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_ItemsLotDivision_Im_PermissionItems");
        });

        modelBuilder.Entity<ImManafest>(entity =>
        {
            entity.ToTable("Im_Manafest", tb => tb.HasComment("منافستو"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ArriveDate).HasComment("تاريخ الوصول");
            entity.Property(e => e.ArriveTime).HasComment("وقت الوصول");
            entity.Property(e => e.CompletionApplicationNum)
                .HasMaxLength(50)
                .HasComment("رقم طلب الاتمام");
            entity.Property(e => e.CustomsCertificate)
                .HasMaxLength(50)
                .HasComment("رقم الشهادة الجمركية");
            entity.Property(e => e.DischargeEndDate).HasComment("تاريخ نهاية التفريغ");
            entity.Property(e => e.EditRecord).HasComment("بيان التعديلات");
            entity.Property(e => e.ExaminationDate).HasComment("تاريخ تسديد الرسالة");
            entity.Property(e => e.GrossWeight)
                .HasComment("الوزن القائم")
                .HasColumnType("numeric(5, 3)");
            entity.Property(e => e.ImporterName)
                .HasMaxLength(50)
                .HasComment("اسم المستورد");
            entity.Property(e => e.IsTransit).HasComment("ترانزيت أم لا");
            entity.Property(e => e.ManafestNum)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("رقم المنافيست")
                .HasColumnName("Manafest_Num");
            entity.Property(e => e.NavigationCompany)
                .HasMaxLength(50)
                .HasComment("شركة الملاحة");
            entity.Property(e => e.NetWeight)
                .HasComment("الوزن الصافي")
                .HasColumnType("numeric(5, 3)")
                .HasColumnName("Net_Weight");
            entity.Property(e => e.Origin)
                .HasMaxLength(50)
                .HasComment("المنشأ(دولة)");
            entity.Property(e => e.PlantName)
                .HasMaxLength(50)
                .HasComment("اسم الصنف");
            entity.Property(e => e.PolicyNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("رقم البوليصة");
            entity.Property(e => e.Quantity).HasComment("العدد");
            entity.Property(e => e.ShipName)
                .HasMaxLength(50)
                .HasComment("اسم الباخرة");
            entity.Property(e => e.ShipmentPort)
                .HasMaxLength(50)
                .HasComment("ميناء الشحن");
            entity.Property(e => e.SubmissionDate).HasComment("تاريخ تقديم المنافيست");
            entity.Property(e => e.ToHagrDate).HasComment("تاريخ التقدم للمنافيستو للحجر");
            entity.Property(e => e.Unit)
                .HasMaxLength(50)
                .HasComment("الوحدة");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<ImOpertaionType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ImportOpertaionType");

            entity.ToTable("Im_OpertaionType", tb => tb.HasComment("أنواع عمليات الوارد"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name_En");
            entity.Property(e => e.WithPermission)
                .HasComment("1 = permission request / 2 = check request / 3 = both permission and check request")
                .HasColumnName("withPermission");
        });

        modelBuilder.Entity<ImPermissionItem>(entity =>
        {
            entity.ToTable("Im_PermissionItems", tb => tb.HasComment("النباتات والمنتجات للوارد"));

            entity.HasIndex(e => new { e.ImPermissionRequestId, e.Id }, "IX_Im_PermissionItems_Permission");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AcceptDate).HasColumnName("Accept_Date");
            entity.Property(e => e.AcceptUserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Accept_User_Creation_Date");
            entity.Property(e => e.AcceptUserCreationId)
                .HasComment("الموظف الذى وافق على الصنف وهذا ليس له علاقة بمن ادخل الصنف( يقرا من الاذن نفسه)")
                .HasColumnName("Accept_User_Creation_Id");
            entity.Property(e => e.AcceptUserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Accept_User_Updation_Date");
            entity.Property(e => e.AcceptUserUpdationId).HasColumnName("Accept_User_Updation_Id");
            entity.Property(e => e.CountryId)
                .HasComment("ConstrainOwner(UnionId/CountryId/ or 0 if Local-Egypt)")
                .HasColumnName("Country_ID");
            entity.Property(e => e.GrossWeight)
                .HasComment("الوزن الاجمالى")
                .HasColumnType("decimal(22, 6)");
            entity.Property(e => e.ImCheckRequestId).HasColumnName("Im_CheckRequest_ID");
            entity.Property(e => e.ImInitiatorId)
                .HasComment("دوله المنشا")
                .HasColumnName("Im_Initiator_ID");
            entity.Property(e => e.ImPermissionRequestId).HasColumnName("Im_PermissionRequest_ID");
            entity.Property(e => e.IsAccepted).HasComment("هل تم الموافقة على الصنف");
            entity.Property(e => e.IsLotDivision)
                .HasComment("1 if divided lots /0 if Sub")
                .HasColumnName("Is_LotDivision");
            entity.Property(e => e.ItemPermissionNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("رقم اذن الاستيراد يأخذ رقم عند الموافقة")
                .HasColumnName("Item_Permission_Number");
            entity.Property(e => e.ItemShortNameId).HasColumnName("Item_ShortName_ID");
            entity.Property(e => e.OrderText)
                .HasComment("الرتبة")
                .HasColumnName("Order_Text");
            entity.Property(e => e.PackageCount)
                .HasComment("عدد العبوات")
                .HasColumnName("Package_Count");
            entity.Property(e => e.PackageMaterialId)
                .HasComment("مادة العبوة")
                .HasColumnName("Package_Material_ID");
            entity.Property(e => e.PackageTypeId)
                .HasComment("نوع العبوة")
                .HasColumnName("Package_Type_ID");
            entity.Property(e => e.PackageWeight)
                .HasComment("وزن العبوة")
                .HasColumnType("decimal(22, 6)")
                .HasColumnName("Package_Weight");
            entity.Property(e => e.QualitativeGroupId).HasColumnName("QualitativeGroup_Id");
            entity.Property(e => e.Size).HasComment("حجم الرسالة");
            entity.Property(e => e.SubPartId)
                .HasComment("جزء نباتى")
                .HasColumnName("SubPart_id");
            entity.Property(e => e.UnitsNumber)
                .HasComment("عدد الوحدات")
                .HasColumnName("Units_Number");

            entity.HasOne(d => d.ImInitiator).WithMany(p => p.ImPermissionItems)
                .HasForeignKey(d => d.ImInitiatorId)
                .HasConstraintName("FK_Im_PermissionItems_Im_Initiator");
        });

        modelBuilder.Entity<ImPermissionItemDivisionCustody>(entity =>
        {
            entity.ToTable("Im_PermissionItem_Division_Custody", tb => tb.HasComment("تقسيم/ نقل الى مكان التحفظ"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AcceptDate)
                .HasComment("تاريخ القبول")
                .HasColumnName("Accept_Date");
            entity.Property(e => e.AcceptUserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Accept_User_Creation_Date");
            entity.Property(e => e.AcceptUserCreationId)
                .HasComment("الموظف الذى وافق على الصنف وهذا ليس له علاقة بمن ادخل الصنف( يقرا من الاذن نفسه)")
                .HasColumnName("Accept_User_Creation_Id");
            entity.Property(e => e.AcceptUserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Accept_User_Updation_Date");
            entity.Property(e => e.AcceptUserUpdationId).HasColumnName("Accept_User_Updation_Id");
            entity.Property(e => e.DriverName)
                .HasMaxLength(250)
                .HasComment("اسم السائق")
                .HasColumnName("Driver_Name");
            entity.Property(e => e.DriverNationalId)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("Driver_National_Id");
            entity.Property(e => e.DriverPhone)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("رقم تليفون السائق")
                .HasColumnName("Driver_Phone");
            entity.Property(e => e.GrossWeight)
                .HasComment("الوزن الاجمالي")
                .HasColumnType("decimal(22, 6)");
            entity.Property(e => e.ImCheckRequestItemId).HasColumnName("Im_CheckRequest_Item_Id");
            entity.Property(e => e.ImCustodyPlaceId)
                .HasComment("كود اماكن التحفظ")
                .HasColumnName("Im_CustodyPlace_Id");
            entity.Property(e => e.IsAccepted)
                .HasDefaultValue(false)
                .HasComment("هل تم الموافقة على التقسيم\r\nحالة الطلب");
            entity.Property(e => e.TransportMeanId)
                .HasComment("كود وسائل النقل")
                .HasColumnName("Transport_Mean_Id");
            entity.Property(e => e.TransportMeanNumber)
                .HasMaxLength(50)
                .HasColumnName("Transport_Mean_Number");

            entity.HasOne(d => d.ImCheckRequestItem).WithMany(p => p.ImPermissionItemDivisionCustodies)
                .HasForeignKey(d => d.ImCheckRequestItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_PermissionItem_Division_Custody_Im_CheckRequest_Items");

            entity.HasOne(d => d.ImCustodyPlace).WithMany(p => p.ImPermissionItemDivisionCustodies)
                .HasForeignKey(d => d.ImCustodyPlaceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_PermissionItem_Division_Custody_Im_CustodyPlace");

            entity.HasOne(d => d.TransportMean).WithMany(p => p.ImPermissionItemDivisionCustodies)
                .HasForeignKey(d => d.TransportMeanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_PermissionItem_Division_Custody_Transport_Mean");
        });

        modelBuilder.Entity<ImPermissionItemDivisionCustodyDismissCommittee>(entity =>
        {
            entity.ToTable("Im_PermissionItem_Division_Custody_DismissCommittee", tb => tb.HasComment("لجنة الصرف"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.DismissDate)
                .HasComment("تاريخ الخروج")
                .HasColumnName("Dismiss_Date");
            entity.Property(e => e.DismissTime).HasComment("وقت الخروج");
            entity.Property(e => e.ImPermissionItemDivisionCustodyId)
                .HasComment("كود نقل مكان التحفظ")
                .HasColumnName("Im_PermissionItem_Division_Custody_Id");
            entity.Property(e => e.ImRequestCommitteeId)
                .HasComment("كود اساسيات اللجنه")
                .HasColumnName("Im_RequestCommittee_Id");
            entity.Property(e => e.IsApproved).HasComment("1 if committe accept else 0");
            entity.Property(e => e.LockLead)
                .HasMaxLength(50)
                .HasComment("ترصيص")
                .HasColumnName("Lock_Lead");
            entity.Property(e => e.Status).HasComment("1 if investigation is done,0 if not done\r\nif car is come or not");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ImPermissionItemDivisionCustody).WithMany(p => p.ImPermissionItemDivisionCustodyDismissCommittees)
                .HasForeignKey(d => d.ImPermissionItemDivisionCustodyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_PermissionItem_Division_Custody_DismissCommittee_Im_PermissionItem_Division_Custody");

            entity.HasOne(d => d.ImRequestCommittee).WithMany(p => p.ImPermissionItemDivisionCustodyDismissCommittees)
                .HasForeignKey(d => d.ImRequestCommitteeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_PermissionItem_Division_Custody_DismissCommittee_Im_RequestCommittee");
        });

        modelBuilder.Entity<ImPermissionItemDivisionCustodyReceiveCommittee>(entity =>
        {
            entity.ToTable("Im_PermissionItem_Division_Custody_ReceiveCommittee", tb => tb.HasComment("لجنة الاستلام"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.GrossWeight)
                .HasComment("الوزن الاجمالي")
                .HasColumnType("decimal(22, 6)");
            entity.Property(e => e.ImPermissionItemDivisionCustodyDismissCommitteeId)
                .HasComment("كود لجنه الصرف")
                .HasColumnName("Im_PermissionItem_Division_Custody_DismissCommittee_Id");
            entity.Property(e => e.ImRequestCommitteeId)
                .HasComment("كود اساسيات اللجنه")
                .HasColumnName("Im_RequestCommittee_Id");
            entity.Property(e => e.IsApproved).HasComment("0 if exporter doesn't accept else 1");
            entity.Property(e => e.ReceiveDate)
                .HasComment("تاريخ الاستلام")
                .HasColumnName("Receive_Date");
            entity.Property(e => e.ReceiveTime).HasComment("وقت الاستلام");
            entity.Property(e => e.Status).HasComment("0 if not done, 1 if investigation is done");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ImPermissionItemDivisionCustodyDismissCommittee).WithMany(p => p.ImPermissionItemDivisionCustodyReceiveCommittees)
                .HasForeignKey(d => d.ImPermissionItemDivisionCustodyDismissCommitteeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_PermissionItem_Division_Custody_ReceiveCommittee_Im_PermissionItem_Division_Custody_DismissCommittee");

            entity.HasOne(d => d.ImRequestCommittee).WithMany(p => p.ImPermissionItemDivisionCustodyReceiveCommittees)
                .HasForeignKey(d => d.ImRequestCommitteeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_PermissionItem_Division_Custody_ReceiveCommittee_Im_RequestCommittee");
        });

        modelBuilder.Entity<ImPermissionItemsCategory>(entity =>
        {
            entity.ToTable("Im_PermissionItems_Category");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.GrossWeight)
                .HasComment("الوزن الاجمالى")
                .HasColumnType("decimal(22, 6)");
            entity.Property(e => e.ImPermissionItemsId).HasColumnName("Im_PermissionItems_ID");
            entity.Property(e => e.ItemCategoryGroupId).HasColumnName("ItemCategoryGroup_ID");
            entity.Property(e => e.ItemCategoryId).HasColumnName("ItemCategory_ID");
            entity.Property(e => e.OrderText)
                .HasComment("الرتبة")
                .HasColumnName("Order_Text");
            entity.Property(e => e.PackageCount)
                .HasComment("عدد العبوات")
                .HasColumnName("Package_Count");
            entity.Property(e => e.PackageMaterialId)
                .HasComment("مادة العبوة")
                .HasColumnName("Package_Material_ID");
            entity.Property(e => e.PackageTypeId)
                .HasComment("نوع العبوة")
                .HasColumnName("Package_Type_ID");
            entity.Property(e => e.PackageWeight)
                .HasComment("وزن العبوة")
                .HasColumnType("decimal(22, 6)")
                .HasColumnName("Package_Weight");
            entity.Property(e => e.ReasonEntry)
                .HasComment("سبب الدخول")
                .HasColumnName("Reason_Entry");
            entity.Property(e => e.Size).HasComment("حجم الرسالة");
            entity.Property(e => e.UnitsNumber)
                .HasComment("عدد الوحدات")
                .HasColumnName("Units_Number");

            entity.HasOne(d => d.ImPermissionItems).WithMany(p => p.ImPermissionItemsCategories)
                .HasForeignKey(d => d.ImPermissionItemsId)
                .HasConstraintName("FK_Im_PermissionItems_Category_Im_PermissionItems");

            entity.HasOne(d => d.ItemCategoryGroup).WithMany(p => p.ImPermissionItemsCategories)
                .HasForeignKey(d => d.ItemCategoryGroupId)
                .HasConstraintName("FK_Im_PermissionItems_Category_ItemCategories_Group");

            entity.HasOne(d => d.ItemCategory).WithMany(p => p.ImPermissionItemsCategories)
                .HasForeignKey(d => d.ItemCategoryId)
                .HasConstraintName("FK_Im_PermissionItems_Category_ItemCategories");
        });

        modelBuilder.Entity<ImPermissionRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Import_PermissionRequest");

            entity.ToTable("Im_PermissionRequest", tb => tb.HasComment("إذن استيراد"));

            entity.HasIndex(e => new { e.UserDeletionId, e.IsAcceppted, e.IsPaid, e.Id }, "IX_Im_PermissionRequest_List").IsDescending(false, false, false, true);

            entity.HasIndex(e => e.ImPermissionNumber, "Im_PermissionRequest_uk").IsUnique();

            entity.HasIndex(e => e.ImPermissionNumber, "UQ_ImPermission_Number").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Amount)
                .HasComment("المبلغ")
                .HasColumnType("money");
            entity.Property(e => e.ArrivalDate)
                .HasComment("تاريخ وصول الشحنة")
                .HasColumnName("Arrival_Date");
            entity.Property(e => e.EndDate)
                .HasComment("تاريخ اخر طباعه")
                .HasColumnName("End_Date");
            entity.Property(e => e.ImCheckRequestId).HasColumnName("Im_CheckRequest_ID");
            entity.Property(e => e.ImPermissionNumber)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("ImPermission_Number");
            entity.Property(e => e.IsNoticeArrival).HasColumnName("IS_Notice_Arrival");
            entity.Property(e => e.IsPaid).HasDefaultValue(false);
            entity.Property(e => e.IsPrintAr).HasColumnName("IS_Print_Ar");
            entity.Property(e => e.IsPrintEn).HasColumnName("IS_Print_EN");
            entity.Property(e => e.PrintCount)
                .HasComment("عدد مرات التجديد")
                .HasColumnName("Print_Count");
            entity.Property(e => e.RenewalStatus)
                .HasComment("حاله التجديد")
                .HasColumnName("Renewal_Status");
            entity.Property(e => e.StartDate)
                .HasComment("تاريخ الاصدار")
                .HasColumnName("Start_Date");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ImCheckRequest).WithMany(p => p.ImPermissionRequests)
                .HasForeignKey(d => d.ImCheckRequestId)
                .HasConstraintName("FK_Im_PermissionRequest_Im_CheckRequest");
        });

        modelBuilder.Entity<ImPermissionRequestHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Im_PermissionRequest_History", tb => tb.HasComment("إذن استيرادوالتجديد"));

            entity.Property(e => e.ArrivalDate)
                .HasComment("تاريخ وصول الشحنة")
                .HasColumnName("Arrival_Date");
            entity.Property(e => e.EndDate)
                .HasComment("تاريخ اخر طباعه")
                .HasColumnName("End_Date");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ImCheckRequestId).HasColumnName("Im_CheckRequest_ID");
            entity.Property(e => e.ImPermissionNumber)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("ImPermission_Number");
            entity.Property(e => e.IsNoticeArrival).HasColumnName("IS_Notice_Arrival");
            entity.Property(e => e.IsPrintAr).HasColumnName("IS_Print_Ar");
            entity.Property(e => e.IsPrintEn).HasColumnName("IS_Print_EN");
            entity.Property(e => e.PrintCount)
                .HasComment("عدد مرات التجديد")
                .HasColumnName("Print_Count");
            entity.Property(e => e.RenewalStatus)
                .HasComment("حاله التجديد")
                .HasColumnName("Renewal_Status");
            entity.Property(e => e.StartDate)
                .HasComment("تاريخ الاصدار")
                .HasColumnName("Start_Date");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<ImPermissionRequestRefuseReason>(entity =>
        {
            entity.ToTable("Im_PermissionRequest_RefuseReason");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ImPermissionRequestId).HasColumnName("Im_PermissionRequest_Id");
            entity.Property(e => e.Isactive).HasColumnName("ISActive");
            entity.Property(e => e.RefuseReasonId).HasColumnName("Refuse_Reason_Id");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");

            entity.HasOne(d => d.ImPermissionRequest).WithMany(p => p.ImPermissionRequestRefuseReasons)
                .HasForeignKey(d => d.ImPermissionRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_PermissionRequest_RefuseReason_Im_PermissionRequest1");

            entity.HasOne(d => d.RefuseReason).WithMany(p => p.ImPermissionRequestRefuseReasons)
                .HasForeignKey(d => d.RefuseReasonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_PermissionRequest_RefuseReason_Refuse_Reason");
        });

        modelBuilder.Entity<ImProcedureType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_LotProcedure");

            entity.ToTable("Im_ProcedureType", tb => tb.HasComment("إجراءات تتم على اللوط (نقل تحت تحفظ/فحص/تحاليل/...)"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name_En");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<ImRequestCommittee>(entity =>
        {
            entity.ToTable("Im_RequestCommittee", tb => tb.HasComment("اساسيات اللجان"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CommitteeTypeId)
                .HasComment("كود الغرض من اللجنه")
                .HasColumnName("CommitteeType_ID");
            entity.Property(e => e.DelegationDate)
                .HasComment("تاريخ الانتداب")
                .HasColumnName("Delegation_Date");
            entity.Property(e => e.EndTime).HasComment("انتهاء ساعة الفحص");
            entity.Property(e => e.ImCheckRequestId).HasColumnName("ImCheckRequest_ID");
            entity.Property(e => e.ImCommitteeCheckLocationId)
                .HasComment("كود اماكن الفحص")
                .HasColumnName("ImCommitteeCheckLocation_ID");
            entity.Property(e => e.IsApproved)
                .HasDefaultValue(false)
                .HasComment("0 if exporter doesn't accept else 1 خاص ب نتيجه الفحص");
            entity.Property(e => e.IsCancel)
                .HasComment("لايقاف او حذف اللجنة مربوط مع  A_SystemCode رقم 31\r\n")
                .HasColumnName("Is_Cancel");
            entity.Property(e => e.IsFinishedAll)
                .HasDefaultValue(false)
                .HasComment("0 if exporter doesn't accept else 1 خاص ب شغل موظف الحجر في فحص الشحنه");
            entity.Property(e => e.IsPaid)
                .HasDefaultValue(false)
                .HasComment("تم الانتهاء من الدفع");
            entity.Property(e => e.IsStartAndroid)
                .HasComment("تعزر عمل اللجنه")
                .HasColumnName("Is_Start_Android");
            entity.Property(e => e.StartTime).HasComment(" بداية ساعة الفحص ");
            entity.Property(e => e.Status)
                .HasDefaultValue(false)
                .HasComment("0 if not done, 1 if investigation is done تم نزول اللجنه 1 ,0 وافق علي معاد اللجنه , null خاص ب العميل عدم الرد عل معاد اللجنه , ");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.CommitteeType).WithMany(p => p.ImRequestCommittees)
                .HasForeignKey(d => d.CommitteeTypeId)
                .HasConstraintName("FK_Im_RequestCommittee_CommitteeType");

            entity.HasOne(d => d.ImCheckRequest).WithMany(p => p.ImRequestCommittees)
                .HasForeignKey(d => d.ImCheckRequestId)
                .HasConstraintName("FK_Im_RequestCommittee_Im_CheckRequest");

            entity.HasOne(d => d.ImCommitteeCheckLocation).WithMany(p => p.ImRequestCommittees)
                .HasForeignKey(d => d.ImCommitteeCheckLocationId)
                .HasConstraintName("FK_Im_RequestCommittee_Im_CommitteeCheckLocation");
        });

        modelBuilder.Entity<ImRequestCommitteeProcedure>(entity =>
        {
            entity.ToTable("Im_RequestCommittee_Procedure", tb => tb.HasComment("اجراءات اللجنة"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ImProcedureTypeId)
                .HasComment("إجراءات تتم على اللوط (نقل تحت تحفظ/فحص/تحاليل/...)")
                .HasColumnName("Im_ProcedureType_ID");
            entity.Property(e => e.ImRequestCommitteeId).HasColumnName("Im_RequestCommittee_ID");
            entity.Property(e => e.ReasonText)
                .HasMaxLength(300)
                .HasComment("السبب")
                .HasColumnName("Reason_Text");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ImProcedureType).WithMany(p => p.ImRequestCommitteeProcedures)
                .HasForeignKey(d => d.ImProcedureTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_RequestCommittee_Procedure_Im_ProcedureType");

            entity.HasOne(d => d.ImRequestCommittee).WithMany(p => p.ImRequestCommitteeProcedures)
                .HasForeignKey(d => d.ImRequestCommitteeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_RequestCommittee_Procedure_Im_RequestCommittee");
        });

        modelBuilder.Entity<ImRequestCommitteeShift>(entity =>
        {
            entity.ToTable("Im_RequestCommittee_Shift", tb => tb.HasComment("نبطشيات اللجنه"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Amount)
                .HasComment("المبلغ")
                .HasColumnType("money");
            entity.Property(e => e.ImRequestCommitteeId).HasColumnName("Im_RequestCommittee_ID");
            entity.Property(e => e.IsPaid).HasDefaultValue(false);
            entity.Property(e => e.ShiftTimingId).HasColumnName("ShiftTiming_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ImRequestCommittee).WithMany(p => p.ImRequestCommitteeShifts)
                .HasForeignKey(d => d.ImRequestCommitteeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_RequestCommittee_Shift_Im_RequestCommittee");

            entity.HasOne(d => d.ShiftTiming).WithMany(p => p.ImRequestCommitteeShifts)
                .HasForeignKey(d => d.ShiftTimingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_RequestCommittee_Shift_ShiftTiming");
        });

        modelBuilder.Entity<ImRequestDatExtra>(entity =>
        {
            entity.ToTable("Im_RequestDat_Extra", tb => tb.HasComment("تفاصيل الشركة او الهيئة"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ImRequestDataId)
                .HasComment("طلب الفحص")
                .HasColumnName("Im_RequestData_ID");
            entity.Property(e => e.ImporeterCompanyAddress).HasComment("عنوان مندوب صاحب الرسالة");
            entity.Property(e => e.ImporeterCompanyAddressEn)
                .HasComment("عنوان مندوب صاحب الرسالة")
                .HasColumnName("ImporeterCompanyAddress_EN");
            entity.Property(e => e.ImportCompany).HasComment("الشركة المستوردة");
            entity.Property(e => e.ImportCompanyEn)
                .HasComment("الشركة المستوردة")
                .HasColumnName("ImportCompany_EN");
            entity.Property(e => e.OwnerAddress).HasComment("عنوان صلحب الرسالة");
            entity.Property(e => e.OwnerName).HasComment("صاحب الرسالة");
            entity.Property(e => e.RecieverName)
                .HasComment("اسم المرسل إليه")
                .HasColumnName("Reciever_Name");

            entity.HasOne(d => d.ImRequestData).WithMany(p => p.ImRequestDatExtras)
                .HasForeignKey(d => d.ImRequestDataId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_RequestDat_Extra_Im_RequestData");
        });

        modelBuilder.Entity<ImRequestDatum>(entity =>
        {
            entity.ToTable("Im_RequestData", tb => tb.HasComment("تفاصيل عناصر الوارد"));

            entity.HasIndex(e => e.ImPermissionRequestId, "IX_Im_RequestData_Permission");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.DelegateAddress)
                .HasMaxLength(100)
                .HasComment("عنوان مندوب صاحب الرسالة");
            entity.Property(e => e.DelegateName)
                .HasMaxLength(50)
                .HasComment("مندوب صاحب الرسالة");
            entity.Property(e => e.ExportCountryId)
                .HasComment("الدولة المصدرة")
                .HasColumnName("ExportCountry_Id");
            entity.Property(e => e.ImCheckRequestId).HasColumnName("Im_CheckRequest_ID");
            entity.Property(e => e.ImOperationType)
                .HasComment("نوع إذن الاستراد")
                .HasColumnName("Im_OperationType");
            entity.Property(e => e.ImPermissionRequestId).HasColumnName("Im_PermissionRequest_ID");
            entity.Property(e => e.ImporterId)
                .HasComment("الشركة/الهيئة/الفرد المستوردة")
                .HasColumnName("Importer_ID");
            entity.Property(e => e.ImporterTypeId)
                .HasComment("from systemcode table 3")
                .HasColumnName("ImporterType_Id");
            entity.Property(e => e.ShipName)
                .HasMaxLength(50)
                .HasComment("اسم الباخرة")
                .HasColumnName("Ship_Name");
            entity.Property(e => e.ShipmentMeanId)
                .HasComment("وسيلة الشحن")
                .HasColumnName("Shipment_Mean_Id");
            entity.Property(e => e.TransportMeanId)
                .HasComment("وسيلة النقل")
                .HasColumnName("Transport_Mean_Id");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ExportCountry).WithMany(p => p.ImRequestData)
                .HasForeignKey(d => d.ExportCountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_RequestData_Country");

            entity.HasOne(d => d.ShipmentMean).WithMany(p => p.ImRequestData)
                .HasForeignKey(d => d.ShipmentMeanId)
                .HasConstraintName("FK_Im_RequestData_Shipment_Mean");

            entity.HasOne(d => d.TransportMean).WithMany(p => p.ImRequestData)
                .HasForeignKey(d => d.TransportMeanId)
                .HasConstraintName("FK_Im_RequestData_Transport_Mean");
        });

        modelBuilder.Entity<ImRequestPort>(entity =>
        {
            entity.ToTable("Im_Request_Port", tb => tb.HasComment("ميناء"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ImRequestDataId)
                .HasComment("طلب الفحص")
                .HasColumnName("Im_RequestData_ID");
            entity.Property(e => e.IsNational)
                .HasDefaultValue(1)
                .HasComment("21 National / 22 International");
            entity.Property(e => e.PortId)
                .HasComment("الميناء")
                .HasColumnName("Port_ID");
            entity.Property(e => e.PortTypeId).HasColumnName("Port_Type_ID");
            entity.Property(e => e.ReqPortTypeId)
                .HasComment("نوع الميناء التصدير\r\ntransit/arrive/shipping")
                .HasColumnName("ReqPortType_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ImRequestData).WithMany(p => p.ImRequestPorts)
                .HasForeignKey(d => d.ImRequestDataId)
                .HasConstraintName("FK_Im_Request_Port_Im_RequestData");

            entity.HasOne(d => d.IsNationalNavigation).WithMany(p => p.ImRequestPortIsNationalNavigations)
                .HasForeignKey(d => d.IsNational)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_Request_Port_A_SystemCode1");

            entity.HasOne(d => d.ReqPortType).WithMany(p => p.ImRequestPortReqPortTypes)
                .HasForeignKey(d => d.ReqPortTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_Request_Port_A_SystemCode");
        });

        modelBuilder.Entity<ImRequestTreatmentDataConfirm>(entity =>
        {
            entity.ToTable("Im_Request_TreatmentData_Confirm");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnType("smalldatetime");
            entity.Property(e => e.ImRequestTreatmentDataId).HasColumnName("Im_Request_TreatmentData_ID");
            entity.Property(e => e.IsAccepted).HasDefaultValue(true);

            entity.HasOne(d => d.ImRequestTreatmentData).WithMany(p => p.ImRequestTreatmentDataConfirms)
                .HasForeignKey(d => d.ImRequestTreatmentDataId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_Request_TreatmentData_Confirm_Im_Request_TreatmentData");
        });

        modelBuilder.Entity<ImRequestTreatmentDatum>(entity =>
        {
            entity.ToTable("Im_Request_TreatmentData");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Amount)
                .HasComment("المبلغ")
                .HasColumnType("money");
            entity.Property(e => e.CompanyId)
                .HasComment("شركة المعالجة")
                .HasColumnName("Company_ID");
            entity.Property(e => e.ExposureDay).HasColumnName("Exposure_Day");
            entity.Property(e => e.ExposureHour).HasColumnName("Exposure_Hour");
            entity.Property(e => e.ExposureMinute).HasColumnName("Exposure_Minute");
            entity.Property(e => e.FeesActual)
                .HasColumnType("money")
                .HasColumnName("Fees_Actual");
            entity.Property(e => e.ImRequestCommitteeId)
                .HasComment("لجنة المعالجة")
                .HasColumnName("Im_RequestCommittee_ID");
            entity.Property(e => e.ImRequestItemId).HasColumnName("Im_Request_Item_Id");
            entity.Property(e => e.ImRequestLotDataId).HasColumnName("Im_Request_LotData_ID");
            entity.Property(e => e.IsFromAndroid)
                .HasDefaultValue(false)
                .HasComment("مين رمي row (system or android)")
                .HasColumnName("IS_From_Android");
            entity.Property(e => e.IsPaid).HasDefaultValue(false);
            entity.Property(e => e.IsTotal)
                .HasComment("(0) in the case of all,(1) in the case of the part في حاله الجزئي او الكلي")
                .HasColumnName("IS_Total");
            entity.Property(e => e.IsTotalAndroid)
                .HasComment("في حاله الفحص لو كلي واتحول الي جزئي")
                .HasColumnName("IS_Total_Android");
            entity.Property(e => e.ItemShortNameId)
                .HasComment("الاسم المختصر ")
                .HasColumnName("Item_ShortName_ID");
            entity.Property(e => e.Size)
                .HasComment("حجم الرسالة (متر مكعب / سم مكعب)")
                .HasColumnType("decimal(22, 6)");
            entity.Property(e => e.StationId)
                .HasComment("مكان المعالجة(محطة معتمدة)")
                .HasColumnName("Station_ID");
            entity.Property(e => e.StationPlace).HasColumnName("Station_Place");
            entity.Property(e => e.Temperature)
                .HasComment("درجة الحرارة")
                .HasColumnType("decimal(5, 2)");
            entity.Property(e => e.TheDose)
                .HasComment("الجرعة")
                .HasColumnType("decimal(22, 6)");
            entity.Property(e => e.ThermalSealNumber)
                .HasComment("رقم الختم الحراري")
                .HasColumnType("numeric(18, 0)");
            entity.Property(e => e.TreatmentMatAmount)
                .HasComment("كمية المادة المستخدمة في المعالجة")
                .HasColumnType("decimal(22, 6)")
                .HasColumnName("TreatmentMat_Amount");
            entity.Property(e => e.TreatmentMatId)
                .HasComment("مادة المعالجة")
                .HasColumnName("TreatmentMat_ID");
            entity.Property(e => e.TreatmentMethodId)
                .HasComment("طريقة المعالجة")
                .HasColumnName("TreatmentMethod_ID");
            entity.Property(e => e.TreatmentTypeId).HasColumnName("TreatmentType_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ImRequestCommittee).WithMany(p => p.ImRequestTreatmentData)
                .HasForeignKey(d => d.ImRequestCommitteeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_Request_TreatmentData_Im_RequestCommittee");

            entity.HasOne(d => d.TreatmentMat).WithMany(p => p.ImRequestTreatmentData)
                .HasForeignKey(d => d.TreatmentMatId)
                .HasConstraintName("FK_Im_Request_TreatmentData_TreatmentMaterial");
        });

        modelBuilder.Entity<ImSampleBarcodeMonthlyCounter>(entity =>
        {
            entity.HasKey(e => e.YearMonth);

            entity.ToTable("Im_SampleBarcodeMonthlyCounter");

            entity.Property(e => e.YearMonth)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<ImScientificResearch>(entity =>
        {
            entity.ToTable("Im_ScientificResearch", tb => tb.HasComment("الرسائل العليمة"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ImPermissionId).HasColumnName("ImPermission_ID");
            entity.Property(e => e.ImScientificResearchOrganizationId).HasColumnName("Im_ScientificResearch_Organization_Id");
            entity.Property(e => e.ImScientificResearchPersonId).HasColumnName("Im_ScientificResearch_Person_Id");
            entity.Property(e => e.OrgManagerNameAr)
                .HasMaxLength(200)
                .HasComment("المدير الحالى")
                .HasColumnName("Org_Manager_Name_Ar");
            entity.Property(e => e.OrgManagerNameEn)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Org_Manager_Name_En");
            entity.Property(e => e.PersonJobTitleAr)
                .HasMaxLength(200)
                .HasComment("الوظيفة الحالية")
                .HasColumnName("Person_Job_Title_Ar");
            entity.Property(e => e.PortNationalId)
                .HasComment("ميناء الدخول")
                .HasColumnName("PortNational_Id");
            entity.Property(e => e.Quantity).HasComment("العدد");
            entity.Property(e => e.ShipmentMeanId)
                .HasComment("وسيلة الشحن")
                .HasColumnName("Shipment_Mean_Id");
            entity.Property(e => e.ShipmentPolicyNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("رقم بوليصة الشحن")
                .HasColumnName("Shipment_Policy_Number");
            entity.Property(e => e.TaxCertificateNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("رقم الشهادة الجمركية")
                .HasColumnName("Tax_Certificate_Number");
            entity.Property(e => e.TransportMeanId)
                .HasComment("وسيلة النقل")
                .HasColumnName("Transport_Mean_Id");
            entity.Property(e => e.TransportMeanName)
                .HasMaxLength(150)
                .HasComment("اسم وسيلة الشحن")
                .HasColumnName("Transport_Mean_Name");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ImPermission).WithMany(p => p.ImScientificResearches)
                .HasForeignKey(d => d.ImPermissionId)
                .HasConstraintName("FK_Im_ScientificResearch_Im_PermissionRequest");

            entity.HasOne(d => d.ImScientificResearchOrganization).WithMany(p => p.ImScientificResearches)
                .HasForeignKey(d => d.ImScientificResearchOrganizationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_ScientificResearch_Im_ScientificResearch_Organization");

            entity.HasOne(d => d.ImScientificResearchPerson).WithMany(p => p.ImScientificResearches)
                .HasForeignKey(d => d.ImScientificResearchPersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_ScientificResearch_Im_ScientificResearch_Person");

            entity.HasOne(d => d.PortNational).WithMany(p => p.ImScientificResearches)
                .HasForeignKey(d => d.PortNationalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_ScientificResearch_PortNational");

            entity.HasOne(d => d.ShipmentMean).WithMany(p => p.ImScientificResearches)
                .HasForeignKey(d => d.ShipmentMeanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_ScientificResearch_Shipment_Mean");

            entity.HasOne(d => d.TransportMean).WithMany(p => p.ImScientificResearches)
                .HasForeignKey(d => d.TransportMeanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_ScientificResearch_Transport_Mean");
        });

        modelBuilder.Entity<ImScientificResearchItemPlantInseketLieble>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Im_ScientificResearch_ItemPlant_Inseket");

            entity.ToTable("Im_ScientificResearch_ItemPlant_Inseket_Lieble", tb => tb.HasComment("افات/حشرات/كائنات"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.BiologicalPhaseId)
                .HasComment("الطور الحيوى")
                .HasColumnName("Biological_Phase_id");
            entity.Property(e => e.ImScientificResearchId).HasColumnName("Im_ScientificResearch_ID");
            entity.Property(e => e.LiableItemsStatusId)
                .HasComment("الحالة")
                .HasColumnName("LiableItems_Status_Id");
            entity.Property(e => e.LiableItemsStrainId)
                .HasComment("السلالة")
                .HasColumnName("LiableItems_Strain_Id");
            entity.Property(e => e.PackageTypeId)
                .HasComment("نوع العبوة")
                .HasColumnName("Package_Type_Id");
            entity.Property(e => e.ProcedureSummery)
                .HasComment("ملخص الاجراءات")
                .HasColumnType("text")
                .HasColumnName("Procedure_Summery");
            entity.Property(e => e.ResearchTypeId)
                .HasComment("نوع الرسالة from systemcode=18\r\n")
                .HasColumnName("Research_Type_Id");
            entity.Property(e => e.ScientificName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("الاسم العلمى")
                .HasColumnName("Scientific_Name");

            entity.HasOne(d => d.BiologicalPhase).WithMany(p => p.ImScientificResearchItemPlantInseketLiebles)
                .HasForeignKey(d => d.BiologicalPhaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_ScientificResearch_ItemPlant_Inseket_Lieble_Biological_Phase");

            entity.HasOne(d => d.ImScientificResearch).WithMany(p => p.ImScientificResearchItemPlantInseketLiebles)
                .HasForeignKey(d => d.ImScientificResearchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_ScientificResearch_ItemPlant_Inseket_Im_ScientificResearch");

            entity.HasOne(d => d.LiableItemsStatus).WithMany(p => p.ImScientificResearchItemPlantInseketLiebles)
                .HasForeignKey(d => d.LiableItemsStatusId)
                .HasConstraintName("FK_Im_ScientificResearch_ItemPlant_Inseket_LiableItems_Status");

            entity.HasOne(d => d.LiableItemsStrain).WithMany(p => p.ImScientificResearchItemPlantInseketLiebles)
                .HasForeignKey(d => d.LiableItemsStrainId)
                .HasConstraintName("FK_Im_ScientificResearch_ItemPlant_Inseket_LiableItems_Strain");

            entity.HasOne(d => d.PackageType).WithMany(p => p.ImScientificResearchItemPlantInseketLiebles)
                .HasForeignKey(d => d.PackageTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_ScientificResearch_ItemPlant_Inseket_Lieble_Package_Type");

            entity.HasOne(d => d.ResearchType).WithMany(p => p.ImScientificResearchItemPlantInseketLiebles)
                .HasForeignKey(d => d.ResearchTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_ScientificResearch_ItemPlant_Inseket_Lieble_A_SystemCode");
        });

        modelBuilder.Entity<ImScientificResearchItemPlantProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Im_ScientificResearch_Items");

            entity.ToTable("Im_ScientificResearch_ItemPlant_Product", tb => tb.HasComment("النبات/ منتج"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ImScientificResearchId).HasColumnName("Im_ScientificResearch_ID");
            entity.Property(e => e.PlantCategories)
                .HasComment("الأصناف الزراعية")
                .HasColumnType("ntext");
            entity.Property(e => e.PlantPartName)
                .HasMaxLength(150)
                .HasComment("اسم الجزء النباتى فى حالة النبات")
                .HasColumnName("PlantPart_Name");
            entity.Property(e => e.ProcedureSummery)
                .HasComment("ملخص الاجراءات")
                .HasColumnType("text")
                .HasColumnName("Procedure_Summery");
            entity.Property(e => e.ProdPlantName)
                .HasMaxLength(150)
                .HasComment("اسم النبات او المنتج")
                .HasColumnName("ProdPlant__Name");
            entity.Property(e => e.ProductStatusId)
                .HasComment("حالة المنتج او النبات")
                .HasColumnName("ProductStatus_Id");
            entity.Property(e => e.ResearchTypeId)
                .HasComment("نوع الرسالة from systemcode=18\r\n")
                .HasColumnName("Research_Type_Id");
            entity.Property(e => e.ScientificName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("الاسم العلمى")
                .HasColumnName("Scientific_Name");

            entity.HasOne(d => d.ImScientificResearch).WithMany(p => p.ImScientificResearchItemPlantProducts)
                .HasForeignKey(d => d.ImScientificResearchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_ScientificResearch_Items_Im_ScientificResearch");

            entity.HasOne(d => d.ProductStatus).WithMany(p => p.ImScientificResearchItemPlantProducts)
                .HasForeignKey(d => d.ProductStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_ScientificResearch_ItemPlant_Product_ProductStatus");

            entity.HasOne(d => d.ResearchType).WithMany(p => p.ImScientificResearchItemPlantProducts)
                .HasForeignKey(d => d.ResearchTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_ScientificResearch_ItemPlant_Product_A_SystemCode");
        });

        modelBuilder.Entity<ImScientificResearchOrganization>(entity =>
        {
            entity.ToTable("Im_ScientificResearch_Organization", tb => tb.HasComment("الجهة المقدمة للطلب"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AddressAr).HasColumnName("Address_AR");
            entity.Property(e => e.AddressEn)
                .IsUnicode(false)
                .HasColumnName("Address_En");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.NameAr)
                .HasMaxLength(300)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("Name_En");
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Phone_No");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<ImScientificResearchPerson>(entity =>
        {
            entity.ToTable("Im_ScientificResearch_Person", tb => tb.HasComment("مقدم الطلب"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AddressAr).HasColumnName("Address_AR");
            entity.Property(e => e.AddressEn)
                .IsUnicode(false)
                .HasColumnName("Address_En");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.NameAr)
                .HasMaxLength(300)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("Name_En");
            entity.Property(e => e.NationalId)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("National_Id");
            entity.Property(e => e.PassportNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Passport_No");
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Phone_No");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<ImStore>(entity =>
        {
            entity.ToTable("Im_Stores", tb => tb.HasComment("المخازن"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fax).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name_En");
            entity.Property(e => e.Phone).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.Place)
                .HasMaxLength(50)
                .HasComment("مخزن/ساحة");
            entity.Property(e => e.StoreOwner).HasMaxLength(50);
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<ImSubDivission>(entity =>
        {
            entity.ToTable("Im_SubDivission", tb => tb.HasComment("تقسيم الرسالة"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CustomsCertificate)
                .HasMaxLength(50)
                .HasColumnName("Customs_Certificate");
            entity.Property(e => e.FilePath).IsUnicode(false);
            entity.Property(e => e.ImItemId).HasColumnName("Im_Item_ID");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ShipmentPolicyNumber)
                .HasMaxLength(50)
                .HasComment("رقم بوليصة الشحن")
                .HasColumnName("ShipmentPolicy_Number");

            entity.HasOne(d => d.ImItem).WithMany(p => p.ImSubDivissions)
                .HasForeignKey(d => d.ImItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Im_SubDivission_Im_PermissionItems");
        });

        modelBuilder.Entity<ImTransUnderCustodyReason>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TransUnderCustodyReason");

            entity.ToTable("Im_TransUnderCustodyReason", tb => tb.HasComment("أسباب النقل تحت التحفظ"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name_En");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<ImVisa>(entity =>
        {
            entity.ToTable("Im_Visa", tb => tb.HasComment("التاشيره"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ArName)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Ar_Name");
            entity.Property(e => e.DescriptionAr).HasColumnName("Description_Ar");
            entity.Property(e => e.DescriptionEn).HasColumnName("Description_En");
            entity.Property(e => e.EnName)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("En_Name");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<ImWarehouse>(entity =>
        {
            entity.ToTable("Im_Warehouses", tb => tb.HasComment("المناشئ"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AddressAr)
                .HasMaxLength(300)
                .HasColumnName("Address_AR");
            entity.Property(e => e.AddressEn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Address_EN");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fax).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name_En");
            entity.Property(e => e.Phone).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.StoreArea)
                .HasMaxLength(50)
                .HasComment("مخزن/ساحة");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.WarehouseTypeNavigation).WithMany(p => p.ImWarehouses)
                .HasForeignKey(d => d.WarehouseType)
                .HasConstraintName("FK_Im_Warehouses_A_SystemCode");
        });

        modelBuilder.Entity<InternationalTransportation>(entity =>
        {
            entity.ToTable("InternationalTransportation");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ArName)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("Ar_Name");
            entity.Property(e => e.EnName)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("En_Name");
            entity.Property(e => e.ShipmentMeanId).HasColumnName("Shipment_Mean_Id");
            entity.Property(e => e.TransferMethod)
                .HasMaxLength(150)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.TransportMeanId).HasColumnName("Transport_Mean_Id");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Plant");

            entity.ToTable("Item", tb => tb.HasComment("النبات و المنتجات"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Agriculture17).HasColumnName("Agriculture_17");
            entity.Property(e => e.DescreptionAr)
                .HasComment("وصف أو تنويه")
                .HasColumnName("Descreption_Ar");
            entity.Property(e => e.DescreptionEn)
                .IsUnicode(false)
                .HasComment("وصف أو تنويه")
                .HasColumnName("Descreption_En");
            entity.Property(e => e.FamilyId).HasColumnName("Family_ID");
            entity.Property(e => e.GroupId).HasColumnName("Group_ID");
            entity.Property(e => e.Hscode).HasColumnName("HSCode");
            entity.Property(e => e.IsForbidden).HasComment("0 مسموح به\r\n1 ممنوع \r\n");
            entity.Property(e => e.IsKnownItem)
                .HasComment("معروف وغير معروف")
                .HasColumnName("Is_known_item");
            entity.Property(e => e.IsPermissionRequest)
                .HasDefaultValue(false)
                .HasComment("هل له اذن استيراد -خاص بالوارد");
            entity.Property(e => e.ItemCode)
                .HasMaxLength(3)
                .HasColumnName("Item_Code");
            entity.Property(e => e.ItemTypeId).HasColumnName("Item_Type_ID");
            entity.Property(e => e.NameAr)
                .HasMaxLength(200)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(200)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("Name_En");
            entity.Property(e => e.Picture).IsUnicode(false);
            entity.Property(e => e.ScientificName).HasColumnName("Scientific_Name");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.Family).WithMany(p => p.Items)
                .HasForeignKey(d => d.FamilyId)
                .HasConstraintName("FK_Plant_Family");

            entity.HasOne(d => d.Group).WithMany(p => p.Items)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK_Plant_Group");
        });

        modelBuilder.Entity<ItemCategoriesGroup>(entity =>
        {
            entity.ToTable("ItemCategories_Group", tb => tb.HasComment("المجموعة الصنفية"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.DescreptionAr).HasColumnName("Descreption_Ar");
            entity.Property(e => e.DescreptionEn)
                .IsUnicode(false)
                .HasColumnName("Descreption_En");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ItemId).HasColumnName("Item_ID");
            entity.Property(e => e.NameAr)
                .HasMaxLength(200)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(200)
                .HasColumnName("Name_En");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<ItemCategoriesType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_LiableItems_Strain");

            entity.ToTable("ItemCategories_Type", tb => tb.HasComment("سلالة البند الخاضع"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Name_En");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<ItemCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PlantCategories");

            entity.ToTable(tb => tb.HasComment("الأصناف الزراعية"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CompanyId)
                .HasComment("الجهة الطالبة للتسجيل")
                .HasColumnName("Company_ID");
            entity.Property(e => e.CurrentStatus).HasComment("if under protection 1 / 0 if not (تحت الحماية أو لا)");
            entity.Property(e => e.IsForbidden).HasComment(" 0 لو ممنوع 1 لو شغال");
            entity.Property(e => e.IsPlantEgypt).HasColumnName("Is_Plant_Egypt");
            entity.Property(e => e.IsRegister).HasComment("هل مسجل ام لا");
            entity.Property(e => e.ItemCategoriesGroupId).HasColumnName("ItemCategories_Group_ID");
            entity.Property(e => e.ItemCategoriesType).HasColumnName("ItemCategories_Type");
            entity.Property(e => e.ItemId).HasColumnName("Item_ID");
            entity.Property(e => e.NameAr)
                .HasMaxLength(200)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Name_En");
            entity.Property(e => e.ProtectProperty)
                .HasComment("قرار حماية الماكية ملف Pdf")
                .HasColumnName("Protect_Property");
            entity.Property(e => e.RegisterEndDate).HasColumnName("Register_EndDate");
            entity.Property(e => e.RegisterNumDate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Register_NumDate");
            entity.Property(e => e.ResolutionDate).HasColumnName("Resolution_Date");
            entity.Property(e => e.ResolutionNumber).HasColumnName("Resolution_Number");
            entity.Property(e => e.TimeOut).HasComment("نهاية المهلة");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.Company).WithMany(p => p.ItemCategories)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_PlantCategories_Company_National");

            entity.HasOne(d => d.ItemCategoriesGroup).WithMany(p => p.ItemCategories)
                .HasForeignKey(d => d.ItemCategoriesGroupId)
                .HasConstraintName("FK_ItemCategories_ItemCategories_Group");

            entity.HasOne(d => d.ItemCategoriesTypeNavigation).WithMany(p => p.ItemCategories)
                .HasForeignKey(d => d.ItemCategoriesType)
                .HasConstraintName("FK_ItemCategories_LiableItems_Strain");

            entity.HasOne(d => d.Item).WithMany(p => p.ItemCategories)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK_PlantCategories_Plant");
        });

        modelBuilder.Entity<ItemPart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PlantPart_1");

            entity.ToTable("ItemPart", tb => tb.HasComment("الجزء النباتى للكائنات"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ItemId).HasColumnName("Item_ID");
            entity.Property(e => e.SubPartId).HasColumnName("SubPart_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.Item).WithMany(p => p.ItemParts)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlantPart_Plant");

            entity.HasOne(d => d.SubPart).WithMany(p => p.ItemParts)
                .HasForeignKey(d => d.SubPartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlantPart_PlantPartType");
        });

        modelBuilder.Entity<ItemPurpose>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ExportPurpose");

            entity.ToTable("Item_Purpose", tb => tb.HasComment("الغرض"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ArName)
                .HasMaxLength(100)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Ar_Name");
            entity.Property(e => e.DescreptionAr)
                .HasComment("وصف أو تنويه")
                .HasColumnName("Descreption_Ar");
            entity.Property(e => e.DescreptionEn)
                .IsUnicode(false)
                .HasComment("وصف أو تنويه")
                .HasColumnName("Descreption_En");
            entity.Property(e => e.EnName)
                .HasMaxLength(100)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("En_Name");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ItemTypeId).HasColumnName("Item_Type_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<ItemShortName>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Plant_ShortName");

            entity.ToTable("Item_ShortName", tb => tb.HasComment("المسمى المختصر"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ExportStatus).HasComment("الموقف من التصدير");
            entity.Property(e => e.Hscode).HasColumnName("HSCode");
            entity.Property(e => e.ImportStatus).HasComment("الموقف من الاستيراد");
            entity.Property(e => e.IsImportTaxFree)
                .HasDefaultValue(false)
                .HasComment("معفي من اذن الاستيراد")
                .HasColumnName("Is_ImportTaxFree");
            entity.Property(e => e.IsShortName)
                .HasComment("له اسم مختصر ام لا")
                .HasColumnName("IS_ShortName");
            entity.Property(e => e.ItemCategoriesGroupId).HasColumnName("ItemCategories_Group_ID");
            entity.Property(e => e.ItemId)
                .HasComment("الصنف")
                .HasColumnName("Item_ID");
            entity.Property(e => e.ItemPurposeId)
                .HasComment("الغرض")
                .HasColumnName("Item_Purpose_ID");
            entity.Property(e => e.ItemStatusId)
                .HasComment("الحالة")
                .HasColumnName("Item_Status_ID");
            entity.Property(e => e.ItemTypeId).HasColumnName("Item_Type_ID");
            entity.Property(e => e.ProductId)
                .HasComment("المنتج")
                .HasColumnName("Product_ID");
            entity.Property(e => e.QualitativeGroupId)
                .HasComment("مجموعة نوعية")
                .HasColumnName("QualitativeGroup_Id");
            entity.Property(e => e.Reason).HasComment("سبب الايقاف");
            entity.Property(e => e.ShortNameAr)
                .HasComment("الاسم العربى")
                .HasColumnName("ShortName_Ar");
            entity.Property(e => e.ShortNameEn)
                .IsUnicode(false)
                .HasComment("الاسم الاجنبى")
                .HasColumnName("ShortName_En");
            entity.Property(e => e.SubPartId)
                .HasComment("الجزء النباتى او الطور الحيوى")
                .HasColumnName("SubPart_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.Item).WithMany(p => p.ItemShortNames)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK_Plant_ShortName_Plant");

            entity.HasOne(d => d.ItemPurpose).WithMany(p => p.ItemShortNames)
                .HasForeignKey(d => d.ItemPurposeId)
                .HasConstraintName("FK_Plant_ShortName_PlantPurpose");

            entity.HasOne(d => d.ItemStatus).WithMany(p => p.ItemShortNames)
                .HasForeignKey(d => d.ItemStatusId)
                .HasConstraintName("FK_Plant_ShortName_ProductStatus");

            entity.HasOne(d => d.QualitativeGroup).WithMany(p => p.ItemShortNames)
                .HasForeignKey(d => d.QualitativeGroupId)
                .HasConstraintName("FK_Plant_ShortName_Item_SpecificGroup");

            entity.HasOne(d => d.SubPart).WithMany(p => p.ItemShortNames)
                .HasForeignKey(d => d.SubPartId)
                .HasConstraintName("FK_Plant_ShortName_PlantPartType");
        });

        modelBuilder.Entity<ItemStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ProductStatus");

            entity.ToTable("Item_Status", tb => tb.HasComment("حالة المنتج"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasComment("")
                .HasColumnName("ID");
            entity.Property(e => e.ArName)
                .HasMaxLength(200)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Ar_Name");
            entity.Property(e => e.DescreptionAr)
                .HasComment("وصف أو تنويه")
                .HasColumnName("Descreption_Ar");
            entity.Property(e => e.DescreptionEn)
                .IsUnicode(false)
                .HasComment("وصف أو تنويه")
                .HasColumnName("Descreption_En");
            entity.Property(e => e.EnName)
                .HasMaxLength(200)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("En_Name");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ItemTypeId).HasColumnName("Item_Type_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<ItemType>(entity =>
        {
            entity.ToTable("Item_Type", tb => tb.HasComment("نوع الصنف نبات, منتج, بند حي..."));

            entity.Property(e => e.Coler)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NameAr)
                .HasMaxLength(200)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Name_En");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<Kingdom>(entity =>
        {
            entity.ToTable("Kingdom", tb => tb.HasComment("المملكه"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("Name_En");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<Level>(entity =>
        {
            entity.ToTable("Level", tb => tb.HasComment("المستوي"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("Name_En");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<LiableItem>(entity =>
        {
            entity.ToTable(tb => tb.HasComment(" "));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.IsAlive).HasComment("كائنات حية/غير حية");
            entity.Property(e => e.IsPermissionRequest)
                .HasDefaultValue(false)
                .HasComment("هل له اذن استيراد -خاص بالوارد");
            entity.Property(e => e.LiableItemsStrainId).HasColumnName("LiableItems_Strain_Id");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Name_En");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.IsAliveNavigation).WithMany(p => p.LiableItems)
                .HasForeignKey(d => d.IsAlive)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LiableItems_A_SystemCode");

            entity.HasOne(d => d.LiableItemsStrain).WithMany(p => p.LiableItems)
                .HasForeignKey(d => d.LiableItemsStrainId)
                .HasConstraintName("FK_LiableItems_LiableItems_Strain");
        });

        modelBuilder.Entity<LiableItemsShortName>(entity =>
        {
            entity.ToTable("LiableItems_ShortName");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.BiologicalPhaseId).HasColumnName("Biological_Phase_ID");
            entity.Property(e => e.ExportStatus).HasComment("الموقف من التصدير");
            entity.Property(e => e.Hscode)
                .HasMaxLength(50)
                .HasColumnName("HSCODE");
            entity.Property(e => e.ImportStatus).HasComment("الموقف من الاستيراد");
            entity.Property(e => e.LiableItemId).HasColumnName("LiableItem_ID");
            entity.Property(e => e.LiableItemsStatusId).HasColumnName("LiableItems_Status_ID");
            entity.Property(e => e.PlantPurposeId).HasColumnName("PlantPurpose_ID");
            entity.Property(e => e.Reason).HasMaxLength(200);
            entity.Property(e => e.ScientficNameAr).HasColumnName("ScientficName_Ar");
            entity.Property(e => e.ScientficNameEn)
                .IsUnicode(false)
                .HasColumnName("ScientficName_En");
            entity.Property(e => e.ShortNameAr).HasColumnName("ShortName_Ar");
            entity.Property(e => e.ShortNameEn)
                .IsUnicode(false)
                .HasColumnName("ShortName_En");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.BiologicalPhase).WithMany(p => p.LiableItemsShortNames)
                .HasForeignKey(d => d.BiologicalPhaseId)
                .HasConstraintName("FK_LiableItems_ShortName_Biological_Phase");

            entity.HasOne(d => d.LiableItem).WithMany(p => p.LiableItemsShortNames)
                .HasForeignKey(d => d.LiableItemId)
                .HasConstraintName("FK_LiableItems_ShortName_LiableItems");

            entity.HasOne(d => d.LiableItemsStatus).WithMany(p => p.LiableItemsShortNames)
                .HasForeignKey(d => d.LiableItemsStatusId)
                .HasConstraintName("FK_LiableItems_ShortName_LiableItems_Status");

            entity.HasOne(d => d.PlantPurpose).WithMany(p => p.LiableItemsShortNames)
                .HasForeignKey(d => d.PlantPurposeId)
                .HasConstraintName("FK_LiableItems_ShortName_PlantPurpose");
        });

        modelBuilder.Entity<LiableItemsStatus>(entity =>
        {
            entity.ToTable("LiableItems_Status", tb => tb.HasComment("حالة البند الخاضع"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.NameAr).HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .IsUnicode(false)
                .HasColumnName("Name_En");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<MainCalssification>(entity =>
        {
            entity.ToTable("MainCalssification", tb => tb.HasComment("الصنف الاساسى"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ItemTypeId).HasColumnName("Item_Type_ID");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("Name_En");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ItemType).WithMany(p => p.MainCalssifications)
                .HasForeignKey(d => d.ItemTypeId)
                .HasConstraintName("FK_MainCalssification_Item_Type");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order", tb => tb.HasComment("الرتبة"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("Name_En");
            entity.Property(e => e.PhylumId).HasColumnName("Phylum_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.Phylum).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PhylumId)
                .HasConstraintName("FK_Order_PhylumSubphylum");
        });

        modelBuilder.Entity<Outlet>(entity =>
        {
            entity.ToTable("Outlet", tb => tb.HasComment("المنفذ"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AddressAr)
                .HasComment("العنوان بالعربية")
                .HasColumnName("Address_Ar");
            entity.Property(e => e.AddressEn)
                .IsUnicode(false)
                .HasComment("العنوان بالانجليزية")
                .HasColumnName("Address_En");
            entity.Property(e => e.ArName)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Ar_Name");
            entity.Property(e => e.EnName)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("En_Name");
            entity.Property(e => e.GrAdminId)
                .HasComment("الادارة العامة")
                .HasColumnName("GrAdmin_ID");
            entity.Property(e => e.IdHr)
                .HasComment("رقم المنفذ بالنسبة لل HR")
                .HasColumnName("ID_HR");
            entity.Property(e => e.IsDisplay)
                .HasDefaultValue((byte)1)
                .HasComment("from system code 21\r\nصادر	/وارد	/صادر+ وارد");
            entity.Property(e => e.IsExport).HasComment("from system code 21\r\nصادر	/وارد	/صادر+ وارد");
            entity.Property(e => e.PortNationalId).HasColumnName("PortNational_ID");
            entity.Property(e => e.SupervisorId)
                .HasComment("مشرف الفرع\r\nFrom HR employee table")
                .HasColumnName("Supervisor_ID");
            entity.Property(e => e.UserCreationDate).HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate).HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate).HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.GrAdmin).WithMany(p => p.Outlets)
                .HasForeignKey(d => d.GrAdminId)
                .HasConstraintName("FK_Outlet_General_Admin");

            entity.HasOne(d => d.IsExportNavigation).WithMany(p => p.Outlets)
                .HasForeignKey(d => d.IsExport)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Outlet_A_SystemCode");
        });

        modelBuilder.Entity<OutletEmployee>(entity =>
        {
            entity.ToTable("Outlet_Employee", tb => tb.HasComment("موظفين المنافذ"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.EmployeeId)
                .HasComment("الموظف")
                .HasColumnName("Employee_Id");
            entity.Property(e => e.OutletId)
                .HasComment("المنافذ")
                .HasColumnName("Outlet_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.Outlet).WithMany(p => p.OutletEmployees)
                .HasForeignKey(d => d.OutletId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Outlet_Employee_Outlet");
        });

        modelBuilder.Entity<PackageMaterial>(entity =>
        {
            entity.ToTable("Package_Material", tb => tb.HasComment("مادة العبوة"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ArName)
                .HasMaxLength(100)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Ar_Name");
            entity.Property(e => e.EnName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("En_Name");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<PackageType>(entity =>
        {
            entity.ToTable("Package_Type", tb => tb.HasComment("نوع العبوة"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ArName)
                .HasMaxLength(100)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Ar_Name");
            entity.Property(e => e.EnName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("En_Name");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<PalletDataExCheckRequestDistribution>(entity =>
        {
            entity.ToTable("Pallet_Data_Ex_CheckRequest_Distribution");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.ExCheckRequestId).HasColumnName("Ex_CheckRequest_ID");
            entity.Property(e => e.PalletDataOrganizationDistributionId).HasColumnName("Pallet_Data_Organization__Distribution_ID");
            entity.Property(e => e.Quantity).HasComment("الكمية الصالحة للتصدير");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ExCheckRequest).WithMany(p => p.PalletDataExCheckRequestDistributions)
                .HasForeignKey(d => d.ExCheckRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pallet_Data_Ex_CheckRequest_Distribution_Ex_CheckRequest");

            entity.HasOne(d => d.PalletDataOrganizationDistribution).WithMany(p => p.PalletDataExCheckRequestDistributions)
                .HasForeignKey(d => d.PalletDataOrganizationDistributionId)
                .HasConstraintName("FK_Pallet_Data_Ex_CheckRequest_Distribution_Pallet_Data_Organization__Distribution");
        });

        modelBuilder.Entity<PalletDataOrganizationDistribution>(entity =>
        {
            entity.ToTable("Pallet_Data_Organization__Distribution");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ExCheckRequestId).HasColumnName("Ex_CheckRequest_ID");
            entity.Property(e => e.OrganizationId)
                .HasComment("رقم الجهة المشتري")
                .HasColumnName("Organization_ID");
            entity.Property(e => e.OrganizationTypeId)
                .HasComment("نوع الجهة المشتري")
                .HasColumnName("Organization_Type_Id");
            entity.Property(e => e.Quantity).HasComment("كمية البالتات");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ExCheckRequest).WithMany(p => p.PalletDataOrganizationDistributions)
                .HasForeignKey(d => d.ExCheckRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pallet_Data_Organization__Distribution_Ex_CheckRequest");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Im_Person");

            entity.ToTable("Person");

            entity.HasIndex(e => e.Id, "_dta_index_Person_15_757017878__K1_2_22");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AddressEn).HasColumnName("Address_EN");
            entity.Property(e => e.CenterId).HasColumnName("Center_ID");
            entity.Property(e => e.CountryId)
                .HasComment("")
                .HasColumnName("Country_ID");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.GovernId).HasColumnName("Govern_ID");
            entity.Property(e => e.Idnumber)
                .HasMaxLength(50)
                .HasComment("رقم قومى/ باسبور")
                .HasColumnName("IDNumber");
            entity.Property(e => e.Name).HasMaxLength(300);
            entity.Property(e => e.NameEn).HasColumnName("Name_EN");
            entity.Property(e => e.PersonIdtype).HasColumnName("Person_IDType");
            entity.Property(e => e.Phone).HasMaxLength(11);
            entity.Property(e => e.UserActivationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Activation_Date");
            entity.Property(e => e.UserActivationId).HasColumnName("User_Activation_Id");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
            entity.Property(e => e.VillageId).HasColumnName("Village_ID");

            entity.HasOne(d => d.Country).WithMany(p => p.People)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_Im_Person_Country");

            entity.HasOne(d => d.PersonIdtypeNavigation).WithMany(p => p.People)
                .HasForeignKey(d => d.PersonIdtype)
                .HasConstraintName("FK_Person_A_SystemCode");
        });

        modelBuilder.Entity<PhylumSubphylum>(entity =>
        {
            entity.ToTable("PhylumSubphylum", tb => tb.HasComment("الشعبه"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.KingdomId).HasColumnName("Kingdom_ID");
            entity.Property(e => e.LevelId).HasColumnName("Level_ID");
            entity.Property(e => e.NameAr)
                .HasMaxLength(200)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("Name_En");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.Kingdom).WithMany(p => p.PhylumSubphylums)
                .HasForeignKey(d => d.KingdomId)
                .HasConstraintName("FK_PhylumSubphylum_Kingdom");

            entity.HasOne(d => d.Level).WithMany(p => p.PhylumSubphylums)
                .HasForeignKey(d => d.LevelId)
                .HasConstraintName("FK_PhylumSubphylum_Level");
        });

        modelBuilder.Entity<PortInternational>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Ports");

            entity.ToTable("Port_International", tb => tb.HasComment("المواني الدوليه"));

            entity.HasIndex(e => new { e.UserDeletionId, e.IsActive }, "_dta_index_Port_International_15_2068306528__K12_K6_1_4_5");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CountryId)
                .HasComment("الدولة")
                .HasColumnName("Country_ID");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Fax)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.NameAr)
                .HasMaxLength(150)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("Name_En");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PortTypeId)
                .HasComment("نوع الميناء")
                .HasColumnName("PortTypeID");
            entity.Property(e => e.RegionsId).HasColumnName("Regions_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.Country).WithMany(p => p.PortInternationals)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_Port_Country");

            entity.HasOne(d => d.PortType).WithMany(p => p.PortInternationals)
                .HasForeignKey(d => d.PortTypeId)
                .HasConstraintName("FK_Ports_Port_Type");

            entity.HasOne(d => d.Regions).WithMany(p => p.PortInternationals)
                .HasForeignKey(d => d.RegionsId)
                .HasConstraintName("FK_Port_International_Regions");
        });

        modelBuilder.Entity<PortNational>(entity =>
        {
            entity.ToTable("PortNational", tb => tb.HasComment("ميناء محلى"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasComment("الميناء")
                .HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Fax)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GovernId)
                .HasComment("المحافظة")
                .HasColumnName("Govern_ID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.NameAr)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("Name_En");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PortOrgainzationId)
                .HasComment("هيئات المواني")
                .HasColumnName("PortOrgainzation_ID");
            entity.Property(e => e.PortTypeId)
                .HasComment("نوع الميناء")
                .HasColumnName("PortTypeID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.Govern).WithMany(p => p.PortNationals)
                .HasForeignKey(d => d.GovernId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PortNational_Governate");

            entity.HasOne(d => d.PortOrgainzation).WithMany(p => p.PortNationals)
                .HasForeignKey(d => d.PortOrgainzationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PortNational_PortOrganization");

            entity.HasOne(d => d.PortType).WithMany(p => p.PortNationals)
                .HasForeignKey(d => d.PortTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PortNational_Port_Type");
        });

        modelBuilder.Entity<PortOrganization>(entity =>
        {
            entity.ToTable("PortOrganization", tb => tb.HasComment("هيئة الموانئ"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ArName)
                .HasMaxLength(150)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Ar_Name");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("البريد الاليكتروني");
            entity.Property(e => e.EnName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("En_Name");
            entity.Property(e => e.Fax)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("الفاكس");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("التليفون");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<PortType>(entity =>
        {
            entity.ToTable("Port_Type", tb => tb.HasComment("أنواع المواني"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DescreptionAr)
                .HasComment("وصف أو تنويه")
                .HasColumnName("Descreption_Ar");
            entity.Property(e => e.DescreptionEn)
                .IsUnicode(false)
                .HasComment("وصف أو تنويه")
                .HasColumnName("Descreption_En");
            entity.Property(e => e.NameAr)
                .HasMaxLength(200)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("Name_En");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<PosInformation>(entity =>
        {
            entity.ToTable("pos_information", tb => tb.HasComment("ماكينات الدفع"));

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BankAccount).HasMaxLength(30);
            entity.Property(e => e.OutletId).HasColumnName("Outlet_ID");
            entity.Property(e => e.Place)
                .HasMaxLength(250)
                .HasColumnName("place");
            entity.Property(e => e.PosNumber)
                .HasMaxLength(100)
                .HasColumnName("pos_number");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Outlet).WithMany(p => p.PosInformations)
                .HasForeignKey(d => d.OutletId)
                .HasConstraintName("FK_pos_information_Outlet");
        });

        modelBuilder.Entity<PublicOrganization>(entity =>
        {
            entity.ToTable("Public_Organization", tb => tb.HasComment("الهيئات العامة"));

            entity.HasIndex(e => e.Id, "_dta_index_Public_Organization_15_1963258149__K1_2_3");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AddressAr)
                .HasComment("العنوان بالعربية")
                .HasColumnName("Address_Ar");
            entity.Property(e => e.AddressEn)
                .IsUnicode(false)
                .HasComment("العنوان بالانجليزية")
                .HasColumnName("Address_En");
            entity.Property(e => e.CenterId).HasColumnName("Center_ID");
            entity.Property(e => e.IsOnlineOffline)
                .HasDefaultValue(false)
                .HasComment("from web/system\r\n1->online\r\n0->offline")
                .HasColumnName("IS_OnlineOffline");
            entity.Property(e => e.NameAr)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("Name_En");
            entity.Property(e => e.PersonIdtype).HasColumnName("Person_IDType");
            entity.Property(e => e.PersonResponsibleAddress).HasColumnName("Person_Responsible_Address");
            entity.Property(e => e.PersonResponsibleCountryId)
                .HasComment("")
                .HasColumnName("Person_Responsible_Country_ID");
            entity.Property(e => e.PersonResponsibleIdnumber)
                .HasMaxLength(50)
                .HasColumnName("PersonResponsible_IDNumber");
            entity.Property(e => e.PersonResponsibleJob).HasColumnName("Person_Responsible_Job");
            entity.Property(e => e.PersonResponsibleName)
                .HasMaxLength(500)
                .HasColumnName("Person_Responsible_Name");
            entity.Property(e => e.PublicOrgTypeId).HasColumnName("PublicOrgType_ID");
            entity.Property(e => e.UserActivationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Activation_Date");
            entity.Property(e => e.UserActivationId).HasColumnName("User_Activation_Id");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
            entity.Property(e => e.VillageId).HasColumnName("Village_ID");

            entity.HasOne(d => d.PublicOrgType).WithMany(p => p.PublicOrganizations)
                .HasForeignKey(d => d.PublicOrgTypeId)
                .HasConstraintName("FK_Public_Organization_PublicOrganization_Type");
        });

        modelBuilder.Entity<PublicOrganizationType>(entity =>
        {
            entity.ToTable("PublicOrganization_Type");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.IsExempt).HasComment("معفى من طلب إذن استيراد");
            entity.Property(e => e.NameAr)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("Name_En");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<QualitativeGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Item_SpecificGroup");

            entity.ToTable("QualitativeGroup", tb => tb.HasComment("مجموعة النوعية"));

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DescreptionAr)
                .HasComment("وصف أو تنويه")
                .HasColumnName("Descreption_Ar");
            entity.Property(e => e.DescreptionEn)
                .IsUnicode(false)
                .HasComment("وصف أو تنويه")
                .HasColumnName("Descreption_En");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.NameAr)
                .HasMaxLength(200)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(200)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("Name_En");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<RefuseReason>(entity =>
        {
            entity.ToTable("Refuse_Reason", tb => tb.HasComment("اسباب رفض الطلب( صادر/وارد)"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasComment("")
                .HasColumnName("ID");
            entity.Property(e => e.ASystemCodeId)
                .HasComment("from systemcode table 20\r\n اذن استراد \r\n طلب فحص وارد 74\r\nfarm 78\r\n")
                .HasColumnName("A_SystemCode_ID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsExport).HasComment("هل يرفض الطلب كله في حالة وجود إصابة");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Name_En");
            entity.Property(e => e.RefusedStopped).HasColumnName("Refused_stopped");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.ToTable(tb => tb.HasComment("المناطق"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CountryId)
                .HasComment("الدولة")
                .HasColumnName("Country_ID");
            entity.Property(e => e.DescreptionAr).HasColumnName("Descreption_Ar");
            entity.Property(e => e.DescreptionEn)
                .IsUnicode(false)
                .HasColumnName("Descreption_En");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasComment("قارة");
            entity.Property(e => e.NameAr)
                .HasMaxLength(200)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(200)
                .HasColumnName("Name_En");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.Country).WithMany(p => p.Regions)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_Regions_Country");
        });

        modelBuilder.Entity<RegionalArea>(entity =>
        {
            entity.ToTable("Regional_Area");

            entity.Property(e => e.Id)
                .HasComment("المناطق الاقليمية")
                .HasColumnName("ID");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasComment("قارة");
            entity.Property(e => e.NameAr)
                .HasMaxLength(200)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(200)
                .HasColumnName("Name_En");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<SecondaryClassification>(entity =>
        {
            entity.ToTable("SecondaryClassification", tb => tb.HasComment("تقسيم فرعى"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.MainClassId).HasColumnName("MainClass_ID");
            entity.Property(e => e.NameAr)
                .HasMaxLength(300)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("Name_En");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.MainClass).WithMany(p => p.SecondaryClassifications)
                .HasForeignKey(d => d.MainClassId)
                .HasConstraintName("FK_SecondaryClassification_MainCalssification");
        });

        modelBuilder.Entity<ShiftTiming>(entity =>
        {
            entity.ToTable("ShiftTiming");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.DayType)
                .HasComment("0 ايام عطلات\r\n1 ايام عادية\r\n")
                .HasColumnName("Day_Type");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Name_En");
            entity.Property(e => e.ShiftTimingFrom).HasColumnName("ShiftTiming_From");
            entity.Property(e => e.ShiftTimingTo).HasColumnName("ShiftTiming_To");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<ShipmentMean>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Shipment_Means");

            entity.ToTable("Shipment_Mean", tb => tb.HasComment("وسائل الشحن"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ArName)
                .HasMaxLength(300)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Ar_Name");
            entity.Property(e => e.EnName)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("En_Name");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<ShippingAgency>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Address).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.NameAr)
                .HasMaxLength(150)
                .HasComment("الاسم بالعربية")
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("Name_En");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<ShippingCompany>(entity =>
        {
            entity.ToTable(tb => tb.HasComment("شركات الشحن الدولية"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Address).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.NameAr)
                .HasMaxLength(150)
                .HasComment("الاسم بالعربية")
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("Name_En");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<Station>(entity =>
        {
            entity.ToTable("Station", tb => tb.HasComment("محطة"));

            entity.HasIndex(e => e.Id, "IX_Station");

            entity.HasIndex(e => e.Id, "IX_Station_1");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AddressAr)
                .HasComment("العنوان بالعربية")
                .HasColumnName("Address_Ar");
            entity.Property(e => e.AddressEn)
                .IsUnicode(false)
                .HasComment("العنوان بالانجليزية")
                .HasColumnName("Address_En");
            entity.Property(e => e.ArName)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Ar_Name");
            entity.Property(e => e.AverageNumberWorkers)
                .HasComment("متوسط عدد العمال")
                .HasColumnName("Average_number_workers");
            entity.Property(e => e.CenterId).HasColumnName("Center_Id");
            entity.Property(e => e.CommertialRecord)
                .HasMaxLength(200)
                .HasComment("السجل التجاري");
            entity.Property(e => e.CompanyId).HasColumnName("Company_ID");
            entity.Property(e => e.EnName)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("En_Name");
            entity.Property(e => e.EndDateIndustrialLicenseNum)
                .HasComment("تاريخ النهاية")
                .HasColumnName("EndDate_Industrial_License_Num");
            entity.Property(e => e.FacilityArea)
                .HasColumnType("numeric(18, 3)")
                .HasColumnName("Facility_area");
            entity.Property(e => e.FastCoolingRefrigerators)
                .HasColumnType("numeric(18, 3)")
                .HasColumnName("Fast_cooling_refrigerators");
            entity.Property(e => e.GovId).HasColumnName("Gov_Id");
            entity.Property(e => e.IndustrialLicenseNum)
                .HasMaxLength(200)
                .HasComment("رقم الترخيص الصناعي")
                .HasColumnName("Industrial_License_Num");
            entity.Property(e => e.IsAccepted).HasComment("موافقة ورفض الطلب\r\n");
            entity.Property(e => e.IsApproved)
                .HasDefaultValue(false)
                .HasComment("لو معتمدة 1");
            entity.Property(e => e.NotesReject)
                .HasComment("اسباب الرفض")
                .HasColumnName("Notes_Reject");
            entity.Property(e => e.NumberShifts)
                .HasComment("عدد الورديات")
                .HasColumnName("Number_Shifts");
            entity.Property(e => e.NumberWorkingDays)
                .HasComment("عدد ايام العمل")
                .HasColumnName("Number_working_Days");
            entity.Property(e => e.ProductionCapacity)
                .HasColumnType("numeric(18, 3)")
                .HasColumnName("Production_capacity");
            entity.Property(e => e.SeasonalAnnual)
                .HasComment("موسمي 0 سنوي 1")
                .HasColumnName("Seasonal_Annual");
            entity.Property(e => e.StartDateIndustrialLicenseNum)
                .HasComment("تاريخ البداية")
                .HasColumnName("StartDate_Industrial_License_Num");
            entity.Property(e => e.StationCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StorageFridgeCapacity)
                .HasColumnType("numeric(18, 3)")
                .HasColumnName("Storage_fridge_capacity");
            entity.Property(e => e.TaxesRecord)
                .HasMaxLength(200)
                .HasComment("السجل الضريبي");
            entity.Property(e => e.TheNumOfProductionLines)
                .HasColumnType("numeric(18, 3)")
                .HasColumnName("The_num_of_production_lines");
            entity.Property(e => e.TheNumOfStorageRefrigerators)
                .HasColumnType("numeric(18, 3)")
                .HasColumnName("The_num_of_storage_refrigerators");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserTypeId)
                .HasComment("from systemcode table 3")
                .HasColumnName("User_Type_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
            entity.Property(e => e.VillageId).HasColumnName("Village_Id");
            entity.Property(e => e.WorkingHours)
                .HasComment("عدد ساعات العمل")
                .HasColumnName("working_hours");
            entity.Property(e => e.YearCreation).HasColumnName("Year_Creation");
        });

        modelBuilder.Entity<StationAccreditation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Station_Accreditation_1");

            entity.ToTable("Station_Accreditation", tb => tb.HasComment(""));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.EndDate).HasComment("تاريخ النهاية");
            entity.Property(e => e.NotesQuarantine).HasColumnName("Notes_Quarantine");
            entity.Property(e => e.StartDate).HasComment("تاريخ البداية");
            entity.Property(e => e.StationAccreditationDataId)
                .HasComment("المحطة")
                .HasColumnName("Station_Accreditation_Data_ID");
            entity.Property(e => e.StationAccreditationRequestId).HasColumnName("Station_Accreditation_Request_ID");
            entity.Property(e => e.StationId)
                .HasComment("المحطة")
                .HasColumnName("Station_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.StationAccreditationData).WithMany(p => p.StationAccreditations)
                .HasForeignKey(d => d.StationAccreditationDataId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Station_Accreditation_Station_Accreditation_Data1");

            entity.HasOne(d => d.Station).WithMany(p => p.StationAccreditations)
                .HasForeignKey(d => d.StationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Station_Accreditation_Station1");
        });

        modelBuilder.Entity<StationAccreditationCheckList>(entity =>
        {
            entity.ToTable("Station_Accreditation_CheckList", tb => tb.HasComment("الاعتمادات وقوائم الاندريد"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.StationAccreditationDataId).HasColumnName("Station_Accreditation_Data_ID");
            entity.Property(e => e.StationCheckListId).HasColumnName("Station_CheckList_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.StationAccreditationData).WithMany(p => p.StationAccreditationCheckLists)
                .HasForeignKey(d => d.StationAccreditationDataId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Station_Accreditation_CheckList_Station_Accreditation_Data");

            entity.HasOne(d => d.StationCheckList).WithMany(p => p.StationAccreditationCheckLists)
                .HasForeignKey(d => d.StationCheckListId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Station_Accreditation_CheckList_Station_CheckList");
        });

        modelBuilder.Entity<StationAccreditationCommittee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Station_Committee");

            entity.ToTable("Station_Accreditation_Committee", tb => tb.HasComment("لجنة اعتماد المحطات"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AmountTotal)
                .HasComment("المبلغ")
                .HasColumnType("money")
                .HasColumnName("Amount_Total");
            entity.Property(e => e.CommitteeTypeId).HasColumnName("CommitteeType_ID");
            entity.Property(e => e.DelegationDate)
                .HasComment("تاريخ الفحص-تاريخ الانتداب")
                .HasColumnName("Delegation_Date");
            entity.Property(e => e.EndTime).HasComment("انتهاء ساعة الفحص");
            entity.Property(e => e.IsAccepted).HasComment("0 if rejected else 1 \r\nlab will set the result");
            entity.Property(e => e.IsApproved).HasComment("null->ask for accredation\r\n0->not accepted\r\n1->Accepted");
            entity.Property(e => e.IsCancel)
                .HasComment("تعزر عمل اللجنه")
                .HasColumnName("Is_Cancel");
            entity.Property(e => e.IsPaid)
                .HasDefaultValue(false)
                .HasComment("تم الانتهاء من الدفع");
            entity.Property(e => e.IsStartAndroid)
                .HasComment("تعزر عمل اللجنه")
                .HasColumnName("Is_Start_Android");
            entity.Property(e => e.NotesRefuseAr)
                .HasMaxLength(300)
                .HasColumnName("Notes_Refuse_Ar");
            entity.Property(e => e.NotesRefuseEn)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("Notes_Refuse_En");
            entity.Property(e => e.StartTime).HasComment(" بداية ساعة الفحص ");
            entity.Property(e => e.StationAccreditationRequestId)
                .HasComment("طلب الفحص")
                .HasColumnName("Station_Accreditation_Request_ID");
            entity.Property(e => e.Status).HasComment("null->No committe ,0 if not done, 1 if investigation is done");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.CommitteeType).WithMany(p => p.StationAccreditationCommittees)
                .HasForeignKey(d => d.CommitteeTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Station_Accreditation_Committee_CommitteeType");

            entity.HasOne(d => d.StationAccreditationRequest).WithMany(p => p.StationAccreditationCommittees)
                .HasForeignKey(d => d.StationAccreditationRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Station_Committee_Station_Accreditation");
        });

        modelBuilder.Entity<StationAccreditationCommitteeCheckList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Station_Accreditation_Committee");

            entity.ToTable("Station_Accreditation_Committee_CheckList", tb => tb.HasComment("نتائج لجنة اعتماد المحطات\r\n"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CommitteeId)
                .HasComment("لجنة سحب العينة")
                .HasColumnName("Committee_ID");
            entity.Property(e => e.IsAccepted).HasComment("0 if rejected else 1 \r\nlab will set the result");
            entity.Property(e => e.IsAcceptedQuarantine)
                .HasComment("0 if rejected else 1 \r\nlab will set the result\r\nموقف الحجر\r\n")
                .HasColumnName("IsAccepted_Quarantine");
            entity.Property(e => e.NotesAr)
                .HasMaxLength(300)
                .HasColumnName("Notes_Ar");
            entity.Property(e => e.NotesEn)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("Notes_En");
            entity.Property(e => e.NotesQuarantine)
                .HasMaxLength(300)
                .HasComment("ملاحظات الحجر")
                .HasColumnName("Notes_Quarantine");
            entity.Property(e => e.StationAccreditationCheckListId).HasColumnName("Station_Accreditation_CheckList_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId)
                .HasComment("Employee ID")
                .HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.Committee).WithMany(p => p.StationAccreditationCommitteeCheckLists)
                .HasForeignKey(d => d.CommitteeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Station_Accreditation_CommitteeData_InvestigateCommittee");

            entity.HasOne(d => d.StationAccreditationCheckList).WithMany(p => p.StationAccreditationCommitteeCheckLists)
                .HasForeignKey(d => d.StationAccreditationCheckListId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Station_Accreditation_Committee_Result_Station_Accreditation_CheckList");
        });

        modelBuilder.Entity<StationAccreditationCommitteeCheckListConfirm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Station_Accreditation_CommitteeResult_Confirm");

            entity.ToTable("Station_Accreditation_Committee_CheckList_Confirm", tb => tb.HasComment("الموافقة على نتيجة الفحص"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnType("smalldatetime");
            entity.Property(e => e.IsAccepted).HasDefaultValue(true);
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.StationAccreditationCommitteeResultId).HasColumnName("Station_Accreditation_CommitteeResult_ID");

            entity.HasOne(d => d.StationAccreditationCommitteeResult).WithMany(p => p.StationAccreditationCommitteeCheckListConfirms)
                .HasForeignKey(d => d.StationAccreditationCommitteeResultId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Station_Accreditation_CommitteeResult_Confirm_Station_Accreditation_CommitteeResult");
        });

        modelBuilder.Entity<StationAccreditationCommitteeFinalResult>(entity =>
        {
            entity.ToTable("Station_Accreditation_Committee_Final_Result");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.IsAccepted)
                .HasDefaultValue(false)
                .HasComment("is admin for the current committee");
            entity.Property(e => e.Isadmin)
                .HasComment("is admin for the current committee")
                .HasColumnName("ISAdmin");
            entity.Property(e => e.NotesCheckList).HasColumnName("Notes_CheckList");
            entity.Property(e => e.NotesFinal).HasColumnName("Notes_final");
            entity.Property(e => e.StationAccreditationCommitteeId)
                .HasComment("لجنة المعالجة")
                .HasColumnName("Station_Accreditation_Committee_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId)
                .HasComment("Employee ID")
                .HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.StationAccreditationCommittee).WithMany(p => p.StationAccreditationCommitteeFinalResults)
                .HasForeignKey(d => d.StationAccreditationCommitteeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Station_Accreditation_Committee_Final_Result_Station_Accreditation_Committee");
        });

        modelBuilder.Entity<StationAccreditationCommitteeImge>(entity =>
        {
            entity.ToTable("Station_Accreditation_Committee_Imge");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AttachmentPathBinary).HasColumnName("AttachmentPath_Binary");
            entity.Property(e => e.InfectionComment)
                .HasComment("نوع المرفق")
                .HasColumnName("Infection_Comment");
            entity.Property(e => e.StationAccreditationCommitteeId).HasColumnName("Station_Accreditation_Committee_id");
            entity.Property(e => e.UserCreationDate)
                .HasComment("null-> for user , value -> if the admin add the row")
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId)
                .HasComment("null-> for user , value -> if the admin add the row")
                .HasColumnName("User_Creation_Id");

            entity.HasOne(d => d.StationAccreditationCommittee).WithMany(p => p.StationAccreditationCommitteeImges)
                .HasForeignKey(d => d.StationAccreditationCommitteeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Station_Accreditation_Committee_Imge_Station_Accreditation_Committee");
        });

        modelBuilder.Entity<StationAccreditationCommitteeShift>(entity =>
        {
            entity.ToTable("Station_Accreditation_Committee_Shift");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Amount)
                .HasComment("المبلغ")
                .HasColumnType("money");
            entity.Property(e => e.IsPaid).HasDefaultValue(false);
            entity.Property(e => e.ShiftTimingId).HasColumnName("ShiftTiming_ID");
            entity.Property(e => e.StationAccreditationCommitteeId).HasColumnName("Station_Accreditation_Committee_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ShiftTiming).WithMany(p => p.StationAccreditationCommitteeShifts)
                .HasForeignKey(d => d.ShiftTimingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Station_Accreditation_Committee_Shift_ShiftTiming");

            entity.HasOne(d => d.StationAccreditationCommittee).WithMany(p => p.StationAccreditationCommitteeShifts)
                .HasForeignKey(d => d.StationAccreditationCommitteeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Station_Accreditation_Committee_Shift_Station_Accreditation_Committee");
        });

        modelBuilder.Entity<StationAccreditationDataCountry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_StationActivityCountry1");

            entity.ToTable("Station_Accreditation_Data_Country", tb => tb.HasComment("بلد نشاط المحطة"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.StationAccreditationDataId).HasColumnName("Station_Accreditation_Data_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.Country).WithMany(p => p.StationAccreditationDataCountries)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StationActivityCountry_Country1");

            entity.HasOne(d => d.StationAccreditationData).WithMany(p => p.StationAccreditationDataCountries)
                .HasForeignKey(d => d.StationAccreditationDataId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Station_Accreditation_Data_Country_Station_Accreditation_Data");
        });

        modelBuilder.Entity<StationAccreditationDataItemShortName>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Station_Plant_Product1");

            entity.ToTable("Station_Accreditation_Data_Item_ShortName", tb => tb.HasComment("المسمى المختصر للاعتماد"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ItemShortNameId).HasColumnName("Item_ShortName_ID");
            entity.Property(e => e.StationAccreditationDataId).HasColumnName("Station_Accreditation_Data_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.ItemShortName).WithMany(p => p.StationAccreditationDataItemShortNames)
                .HasForeignKey(d => d.ItemShortNameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Station_Item_ShortName_Item_ShortName");

            entity.HasOne(d => d.StationAccreditationData).WithMany(p => p.StationAccreditationDataItemShortNames)
                .HasForeignKey(d => d.StationAccreditationDataId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Station_Accreditation_Data_Item_ShortName_Station_Accreditation_Data");
        });

        modelBuilder.Entity<StationAccreditationDatum>(entity =>
        {
            entity.ToTable("Station_Accreditation_Data", tb => tb.HasComment("مسمى الاعتماد"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AccreditationTypeId)
                .HasComment("A_SystemCode id =21")
                .HasColumnName("Accreditation_Type_ID");
            entity.Property(e => e.DescriptionAr)
                .HasComment("العنوان بالعربية")
                .HasColumnName("Description_Ar");
            entity.Property(e => e.DescriptionEn)
                .IsUnicode(false)
                .HasComment("العنوان بالانجليزية")
                .HasColumnName("Description_En");
            entity.Property(e => e.DescriptionMoreAr).HasColumnName("DescriptionMore_AR");
            entity.Property(e => e.DescriptionMoreEn)
                .IsUnicode(false)
                .HasColumnName("DescriptionMore_EN");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Name_AR");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("Name_En");
            entity.Property(e => e.StationActivityTypeId)
                .HasComment("نوع النشاط")
                .HasColumnName("StationActivityType_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.AccreditationType).WithMany(p => p.StationAccreditationData)
                .HasForeignKey(d => d.AccreditationTypeId)
                .HasConstraintName("FK_Station_Accreditation_Data_A_SystemCode");

            entity.HasOne(d => d.StationActivityType).WithMany(p => p.StationAccreditationData)
                .HasForeignKey(d => d.StationActivityTypeId)
                .HasConstraintName("FK_Station_Accreditation_Data_StationActivityType");
        });

        modelBuilder.Entity<StationAccreditationRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Station_Accreditation");

            entity.ToTable("Station_Accreditation_Request", tb => tb.HasComment("اعتماد المحطة"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AmountTotal)
                .HasDefaultValue(0m)
                .HasComment("المبلغ")
                .HasColumnType("money")
                .HasColumnName("Amount_Total");
            entity.Property(e => e.CommitteeTypeId).HasColumnName("CommitteeType_ID");
            entity.Property(e => e.EndDate).HasComment("تاريخ النهاية");
            entity.Property(e => e.IsAccepted).HasComment("موافقة ورفض الطلب\r\n");
            entity.Property(e => e.IsFinalRequst)
                .HasComment("الموقف النهائي للطلب\r\nnull لم يتم العمل على الطلب\r\n0 يتم العمل على الطلب\r\n1 تم الانتهاء من العمل على الطلب")
                .HasColumnName("Is_Final_requst");
            entity.Property(e => e.IsPaid)
                .HasDefaultValue(false)
                .HasComment("تم الانتهاء من الدفع");
            entity.Property(e => e.NotesQuarantine).HasColumnName("Notes_Quarantine");
            entity.Property(e => e.StartDate).HasComment("تاريخ البداية");
            entity.Property(e => e.StationAccreditationDataId)
                .HasComment("المحطة")
                .HasColumnName("Station_Accreditation_Data_ID");
            entity.Property(e => e.StationAccreditationRequestTypeId).HasColumnName("Station_Accreditation_Request_Type_ID");
            entity.Property(e => e.StationId)
                .HasComment("المحطة")
                .HasColumnName("Station_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.CommitteeType).WithMany(p => p.StationAccreditationRequests)
                .HasForeignKey(d => d.CommitteeTypeId)
                .HasConstraintName("FK_Station_Accreditation_Request_CommitteeType");

            entity.HasOne(d => d.StationAccreditationData).WithMany(p => p.StationAccreditationRequests)
                .HasForeignKey(d => d.StationAccreditationDataId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Station_Accreditation_Station_Accreditation_Data");

            entity.HasOne(d => d.StationAccreditationRequestType).WithMany(p => p.StationAccreditationRequests)
                .HasForeignKey(d => d.StationAccreditationRequestTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Station_Accreditation_Request_Station_Accreditation_Request_Type");

            entity.HasOne(d => d.Station).WithMany(p => p.StationAccreditationRequests)
                .HasForeignKey(d => d.StationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Station_Accreditation_Station");
        });

        modelBuilder.Entity<StationAccreditationRequestFee>(entity =>
        {
            entity.ToTable("Station_Accreditation_Request_Fees");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.IsPaid)
                .HasDefaultValue(false)
                .HasComment("تم الانتهاء من الدفع");
            entity.Property(e => e.StationAccreditationRequestId).HasColumnName("Station_Accreditation_Request_ID");
            entity.Property(e => e.StationFeesTypeId).HasColumnName("Station_Fees_Type_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
            entity.Property(e => e.Value).HasColumnType("money");

            entity.HasOne(d => d.StationAccreditationRequest).WithMany(p => p.StationAccreditationRequestFees)
                .HasForeignKey(d => d.StationAccreditationRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Station_Accreditation_Request_Fees_Station_Accreditation_Request");

            entity.HasOne(d => d.StationFeesType).WithMany(p => p.StationAccreditationRequestFees)
                .HasForeignKey(d => d.StationFeesTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Station_Accreditation_Request_Fees_Station_Fees_Type");
        });

        modelBuilder.Entity<StationAccreditationRequestFeesEng>(entity =>
        {
            entity.ToTable("Station_Accreditation_Request_Fees_ENG");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.IsPaid)
                .HasDefaultValue(false)
                .HasComment("تم الانتهاء من الدفع");
            entity.Property(e => e.NumEng)
                .HasDefaultValue(1)
                .HasColumnName("Num_Eng");
            entity.Property(e => e.StationAccreditationCommitteeId).HasColumnName("Station_Accreditation_Committee_ID");
            entity.Property(e => e.StationFeesTypeId).HasColumnName("Station_Fees_Type_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
            entity.Property(e => e.Value).HasColumnType("money");

            entity.HasOne(d => d.StationAccreditationCommittee).WithMany(p => p.StationAccreditationRequestFeesEngs)
                .HasForeignKey(d => d.StationAccreditationCommitteeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Station_Accreditation_Request_Fees_ENG_Station_Accreditation_Committee");

            entity.HasOne(d => d.StationFeesType).WithMany(p => p.StationAccreditationRequestFeesEngs)
                .HasForeignKey(d => d.StationFeesTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Station_Accreditation_Request_Fees_ENG_Station_Fees_Type");
        });

        modelBuilder.Entity<StationAccreditationRequestType>(entity =>
        {
            entity.ToTable("Station_Accreditation_Request_Type");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("Name_AR");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("Name_EN");
        });

        modelBuilder.Entity<StationActivityType>(entity =>
        {
            entity.ToTable("StationActivityType", tb => tb.HasComment("أنواع أنشطة المحطة"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ArName)
                .HasMaxLength(100)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Ar_Name");
            entity.Property(e => e.DescreptionAr)
                .HasComment("وصف أو تنويه")
                .HasColumnName("Descreption_Ar");
            entity.Property(e => e.DescreptionEn)
                .IsUnicode(false)
                .HasComment("وصف أو تنويه")
                .HasColumnName("Descreption_En");
            entity.Property(e => e.EnName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("En_Name");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.TreatmentMethodsId).HasColumnName("TreatmentMethods_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.TreatmentMethods).WithMany(p => p.StationActivityTypes)
                .HasForeignKey(d => d.TreatmentMethodsId)
                .HasConstraintName("FK_StationActivityType_TreatmentMethods");
        });

        modelBuilder.Entity<StationCheckList>(entity =>
        {
            entity.ToTable("Station_CheckList", tb => tb.HasComment("شروط الاندريد"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ConstrainTextAr).HasColumnName("ConstrainText_Ar");
            entity.Property(e => e.ConstrainTextEn)
                .IsUnicode(false)
                .HasColumnName("ConstrainText_En");
            entity.Property(e => e.DescriptionAr).HasColumnName("Description_Ar");
            entity.Property(e => e.DescriptionEn)
                .IsUnicode(false)
                .HasColumnName("Description_En");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasComment("");
            entity.Property(e => e.IsAndroud)
                .HasComment("شهادة الصحة النباتية")
                .HasColumnName("Is_Androud");
            entity.Property(e => e.NumberCheck).HasColumnName("Number_Check");
            entity.Property(e => e.StationConstrainCountryItemId).HasColumnName("Station_Constrain_Country_Item_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.StationConstrainCountryItem).WithMany(p => p.StationCheckLists)
                .HasForeignKey(d => d.StationConstrainCountryItemId)
                .HasConstraintName("FK_Station_CheckList_Station_Constrain_Country_Item1");
        });

        modelBuilder.Entity<StationCommittee>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Station_Committee");

            entity.Property(e => e.CommitteeUserDeletionId).HasColumnName("Committee_User_Deletion_Id");
            entity.Property(e => e.DelegationDate).HasColumnName("Delegation_Date");
            entity.Property(e => e.IsCancel).HasColumnName("Is_Cancel");
            entity.Property(e => e.IsStartAndroid).HasColumnName("Is_Start_Android");
            entity.Property(e => e.StationAccreditationCommitteeId).HasColumnName("Station_Accreditation_Committee_ID");
            entity.Property(e => e.StationAccreditationRequestId).HasColumnName("Station_Accreditation_Request_ID");
        });

        modelBuilder.Entity<StationCompany>(entity =>
        {
            entity.ToTable("StationCompany", tb => tb.HasComment("شركات المحطة"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CompanyId).HasColumnName("Company_ID");
            entity.Property(e => e.CompanyTypeId)
                .HasComment("from systemcode table 3")
                .HasColumnName("Company_Type_Id");
            entity.Property(e => e.EndDate).HasColumnName("End_Date");
            entity.Property(e => e.StartDate).HasColumnName("Start_Date");
            entity.Property(e => e.StationAccreditationId).HasColumnName("Station_Accreditation_ID");
            entity.Property(e => e.Status).HasComment("2 تحت الدراسة\r\n1 مقبول\r\n0 مرفوض\r\n3 ايقاف\r\n\r\n\r\n");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.StationAccreditation).WithMany(p => p.StationCompanies)
                .HasForeignKey(d => d.StationAccreditationId)
                .HasConstraintName("FK_StationCompany_Station_Accreditation");
        });

        modelBuilder.Entity<StationConstrainCountryItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_EX_Station_Type");

            entity.ToTable("Station_Constrain_Country_Item", tb => tb.HasComment("انواع الاشتراطات"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ArName)
                .HasMaxLength(150)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Ar_Name");
            entity.Property(e => e.EnName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("En_Name");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasComment("مفعل");
            entity.Property(e => e.StationTypeId).HasColumnName("Station_Type_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.StationType).WithMany(p => p.StationConstrainCountryItems)
                .HasForeignKey(d => d.StationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EX_Station_Type_EX_Constrain");
        });

        modelBuilder.Entity<StationConstrainType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_EX_Station");

            entity.ToTable("Station_Constrain_Type", tb => tb.HasComment(" الاشتراطات"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ArName)
                .HasMaxLength(150)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Ar_Name");
            entity.Property(e => e.EnName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("En_Name");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasComment("مفعل");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<StationContact>(entity =>
        {
            entity.ToTable(tb => tb.HasComment("وسائل اتصال المحطة"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ContactTypeId)
                .HasComment("نوع وسيلة الاتصال")
                .HasColumnName("ContactType_ID");
            entity.Property(e => e.StationId).HasColumnName("StationID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
            entity.Property(e => e.Value)
                .HasMaxLength(150)
                .HasComment("الرقم");

            entity.HasOne(d => d.ContactType).WithMany(p => p.StationContacts)
                .HasForeignKey(d => d.ContactTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StationContacts_ContactType");

            entity.HasOne(d => d.Station).WithMany(p => p.StationContacts)
                .HasForeignKey(d => d.StationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StationContacts_Station");
        });

        modelBuilder.Entity<StationDatum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Station_Data");

            entity.Property(e => e.ArName).HasColumnName("Ar_Name");
            entity.Property(e => e.CenterArName)
                .HasMaxLength(150)
                .HasColumnName("Center_Ar_Name");
            entity.Property(e => e.CenterId).HasColumnName("Center_Id");
            entity.Property(e => e.CompanyId).HasColumnName("Company_ID");
            entity.Property(e => e.CompanyName).HasColumnName("Company_Name");
            entity.Property(e => e.GovArName)
                .HasMaxLength(150)
                .HasColumnName("Gov_Ar_Name");
            entity.Property(e => e.GovId).HasColumnName("Gov_Id");
            entity.Property(e => e.StationCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StationId).HasColumnName("Station_ID");
            entity.Property(e => e.StationIsAccepted).HasColumnName("station_IsAccepted");
            entity.Property(e => e.StationIsActive).HasColumnName("station_IsActive");
            entity.Property(e => e.StationUserDeletionId).HasColumnName("Station_User_Deletion_Id");
            entity.Property(e => e.VillageArName)
                .HasMaxLength(200)
                .HasColumnName("Village_Ar_Name");
            entity.Property(e => e.VillageId).HasColumnName("Village_Id");
        });

        modelBuilder.Entity<StationEmp>(entity =>
        {
            entity.ToTable("Station_Emp");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateFrom).HasColumnName("Date_From");
            entity.Property(e => e.DateTo).HasColumnName("Date_To");
            entity.Property(e => e.EmpId).HasColumnName("Emp_Id");
            entity.Property(e => e.StationId).HasColumnName("Station_Id");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.Station).WithMany(p => p.StationEmps)
                .HasForeignKey(d => d.StationId)
                .HasConstraintName("FK_Station_Emp_Station");
        });

        modelBuilder.Entity<StationFeesType>(entity =>
        {
            entity.ToTable("Station_Fees_Type");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AccountType)
                .HasComment("نوع الحساب من  system code رقم 33")
                .HasColumnName("Account_Type");
            entity.Property(e => e.FeesActionId)
                .HasComment("نوع الوردية وقيمتها")
                .HasColumnName("Fees_Action_ID");
            entity.Property(e => e.FeesType)
                .HasComment("صادر وارد ورية مهندس\r\nرقم 20\r\nفى system code\r\n")
                .HasColumnName("Fees_Type");
            entity.Property(e => e.Value).HasColumnType("money");
        });

        modelBuilder.Entity<StationList>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Station_List");

            entity.Property(e => e.AccreditationTypeId).HasColumnName("Accreditation_Type_ID");
            entity.Property(e => e.ArName).HasColumnName("Ar_Name");
            entity.Property(e => e.CenterArName)
                .HasMaxLength(150)
                .HasColumnName("Center_Ar_Name");
            entity.Property(e => e.CenterId).HasColumnName("Center_Id");
            entity.Property(e => e.CommitteeUserDeletionId).HasColumnName("Committee_User_Deletion_Id");
            entity.Property(e => e.CompanyId).HasColumnName("Company_ID");
            entity.Property(e => e.CompanyName).HasColumnName("Company_Name");
            entity.Property(e => e.DelegationDate).HasColumnName("Delegation_Date");
            entity.Property(e => e.Expr1)
                .HasMaxLength(53)
                .IsUnicode(false);
            entity.Property(e => e.GovArName)
                .HasMaxLength(150)
                .HasColumnName("Gov_Ar_Name");
            entity.Property(e => e.GovId).HasColumnName("Gov_Id");
            entity.Property(e => e.IsCancel).HasColumnName("Is_Cancel");
            entity.Property(e => e.IsFinalRequst).HasColumnName("Is_Final_requst");
            entity.Property(e => e.IsStartAndroid).HasColumnName("Is_Start_Android");
            entity.Property(e => e.RequestUserDeletionId).HasColumnName("Request_User_Deletion_Id");
            entity.Property(e => e.StationAccreditationCommitteeId).HasColumnName("Station_Accreditation_Committee_ID");
            entity.Property(e => e.StationAccreditationDataId).HasColumnName("Station_Accreditation_Data_ID");
            entity.Property(e => e.StationAccreditationDataIsActive).HasColumnName("Station_Accreditation_Data_IsActive");
            entity.Property(e => e.StationAccreditationDataName)
                .HasMaxLength(100)
                .HasColumnName("Station_Accreditation_Data_Name");
            entity.Property(e => e.StationAccreditationRequestId).HasColumnName("Station_Accreditation_Request_ID");
            entity.Property(e => e.StationAccreditationRequestIsAccepted).HasColumnName("Station_Accreditation_Request_IsAccepted");
            entity.Property(e => e.StationAccreditationRequestIsactive).HasColumnName("Station_Accreditation_Request_ISActive");
            entity.Property(e => e.StationAccreditationRequestIspaid).HasColumnName("Station_Accreditation_Request_ISpaid");
            entity.Property(e => e.StationAccreditationRequestTypeId).HasColumnName("Station_Accreditation_Request_Type_ID");
            entity.Property(e => e.StationAccreditationRequestTypeIsActive).HasColumnName("Station_Accreditation_Request_Type_IsActive");
            entity.Property(e => e.StationAccreditationRequestTypeName)
                .HasMaxLength(50)
                .HasColumnName("Station_Accreditation_Request_Type_Name");
            entity.Property(e => e.StationActivityTypeId).HasColumnName("StationActivityType_ID");
            entity.Property(e => e.StationBtn).HasColumnName("station_btn");
            entity.Property(e => e.StationCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StationId).HasColumnName("Station_ID");
            entity.Property(e => e.StationIsAccepted).HasColumnName("station_IsAccepted");
            entity.Property(e => e.StationIsActive).HasColumnName("station_IsActive");
            entity.Property(e => e.StationStatus)
                .HasMaxLength(53)
                .IsUnicode(false)
                .HasColumnName("station_Status");
            entity.Property(e => e.StationUserDeletionId).HasColumnName("Station_User_Deletion_Id");
            entity.Property(e => e.VillageArName)
                .HasMaxLength(200)
                .HasColumnName("Village_Ar_Name");
            entity.Property(e => e.VillageId).HasColumnName("Village_Id");
        });

        modelBuilder.Entity<StationManagingDirector>(entity =>
        {
            entity.ToTable("Station_Managing_Director", tb => tb.HasComment("المدير المسئول"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasComment("المدير المسئول")
                .HasColumnName("ID");
            entity.Property(e => e.AddressAr)
                .HasComment("العنوان بالعربية")
                .HasColumnName("Address_Ar");
            entity.Property(e => e.AddressEn)
                .IsUnicode(false)
                .HasComment("العنوان بالانجليزية")
                .HasColumnName("Address_En");
            entity.Property(e => e.ArName)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Ar_Name");
            entity.Property(e => e.EnName)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("En_Name");
            entity.Property(e => e.ManagingDirectorNid)
                .HasMaxLength(14)
                .HasColumnName("Managing_Director_NID");
            entity.Property(e => e.Mobile).HasMaxLength(11);
            entity.Property(e => e.StationId).HasColumnName("StationID");

            entity.HasOne(d => d.Station).WithMany(p => p.StationManagingDirectors)
                .HasForeignKey(d => d.StationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Station_Managing_Director_Station");
        });

        modelBuilder.Entity<StationRequst>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Station_Requst");

            entity.Property(e => e.AccreditationTypeId).HasColumnName("Accreditation_Type_ID");
            entity.Property(e => e.IsFinalRequst).HasColumnName("Is_Final_requst");
            entity.Property(e => e.RequestUserDeletionId).HasColumnName("Request_User_Deletion_Id");
            entity.Property(e => e.StationAccreditationDataId).HasColumnName("Station_Accreditation_Data_ID");
            entity.Property(e => e.StationAccreditationDataIsActive).HasColumnName("Station_Accreditation_Data_IsActive");
            entity.Property(e => e.StationAccreditationDataName)
                .HasMaxLength(100)
                .HasColumnName("Station_Accreditation_Data_Name");
            entity.Property(e => e.StationAccreditationRequestId).HasColumnName("Station_Accreditation_Request_ID");
            entity.Property(e => e.StationAccreditationRequestIsAccepted).HasColumnName("Station_Accreditation_Request_IsAccepted");
            entity.Property(e => e.StationAccreditationRequestIsactive).HasColumnName("Station_Accreditation_Request_ISActive");
            entity.Property(e => e.StationAccreditationRequestIspaid).HasColumnName("Station_Accreditation_Request_ISpaid");
            entity.Property(e => e.StationAccreditationRequestTypeId).HasColumnName("Station_Accreditation_Request_Type_ID");
            entity.Property(e => e.StationAccreditationRequestTypeIsActive).HasColumnName("Station_Accreditation_Request_Type_IsActive");
            entity.Property(e => e.StationAccreditationRequestTypeName)
                .HasMaxLength(50)
                .HasColumnName("Station_Accreditation_Request_Type_Name");
            entity.Property(e => e.StationActivityTypeId).HasColumnName("StationActivityType_ID");
            entity.Property(e => e.StationId).HasColumnName("Station_ID");
        });

        modelBuilder.Entity<SteamingCompany>(entity =>
        {
            entity.ToTable("SteamingCompany", tb => tb.HasComment("شركات التبخير"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CompanyId)
                .HasComment("شركة المكافحة")
                .HasColumnName("Company_ID");
            entity.Property(e => e.GasCompanyId)
                .HasComment("شركة استيراد الغاز")
                .HasColumnName("GasCompany_ID");
            entity.Property(e => e.OutGasAmount)
                .HasComment("كمية الغاز المنصرف للمعالجة")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("OutGas_Amount");
            entity.Property(e => e.OutGasDate)
                .HasComment("تاريخ الصرف")
                .HasColumnName("OutGas_Date");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.Company).WithMany(p => p.SteamingCompanies)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_SteamingCompany_Company_National");

            entity.HasOne(d => d.GasCompany).WithMany(p => p.SteamingCompanies)
                .HasForeignKey(d => d.GasCompanyId)
                .HasConstraintName("FK_SteamingCompany_Gas_ImportCompany");
        });

        modelBuilder.Entity<SubPart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PlantPart");

            entity.ToTable("SubPart", tb => tb.HasComment("الجزء النباتي والطور الحيوى"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.DescreptionAr)
                .HasComment("وصف أو تنويه")
                .HasColumnName("Descreption_Ar");
            entity.Property(e => e.DescreptionEn)
                .IsUnicode(false)
                .HasComment("وصف أو تنويه")
                .HasColumnName("Descreption_En");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasComment("مسموح/غير مسموح");
            entity.Property(e => e.ItemTypeId).HasColumnName("Item_Type_ID");
            entity.Property(e => e.NameAr)
                .HasMaxLength(200)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Name_En");
            entity.Property(e => e.SubPartTypeId).HasColumnName("SubPart_Type_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.SubPartType).WithMany(p => p.SubParts)
                .HasForeignKey(d => d.SubPartTypeId)
                .HasConstraintName("FK_SubPart_SubPart_Type");
        });

        modelBuilder.Entity<SubPartType>(entity =>
        {
            entity.ToTable("SubPart_Type");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.DescreptionAr)
                .HasComment("وصف أو تنويه")
                .HasColumnName("Descreption_Ar");
            entity.Property(e => e.DescreptionEn)
                .IsUnicode(false)
                .HasComment("وصف أو تنويه")
                .HasColumnName("Descreption_En");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasComment("مسموح/غير مسموح");
            entity.Property(e => e.NameAr)
                .HasMaxLength(200)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Name_En");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<TableAction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Table_Ac__3214EC27682E7DA8");

            entity.ToTable("Table_Action");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.IdTableName).HasColumnName("ID_Table_Name");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Name_En");
            entity.Property(e => e.Nots)
                .HasMaxLength(100)
                .HasColumnName("NOTS");
            entity.Property(e => e.NotsAr)
                .HasMaxLength(100)
                .HasColumnName("NOTS_Ar");
            entity.Property(e => e.NotsEn)
                .HasMaxLength(100)
                .HasColumnName("NOTS_En");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.IdTableNameNavigation).WithMany(p => p.TableActions)
                .HasForeignKey(d => d.IdTableName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Table_Action_A_AttachmentTableName");
        });

        modelBuilder.Entity<TableActionLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Table_Ac__3214EC27772B206F");

            entity.ToTable("Table_Action_Log");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.IdTableAction).HasColumnName("ID_Table_Action");
            entity.Property(e => e.IdTableActionValue).HasColumnName("ID_TableActionValue");
            entity.Property(e => e.ImPermissionRequestId).HasColumnName("Im_PermissionRequest_ID");
            entity.Property(e => e.Nots)
                .HasMaxLength(100)
                .HasColumnName("NOTS");
            entity.Property(e => e.TypeLogId)
                .HasComment("from A_SystemCode =32")
                .HasColumnName("Type_log_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserTypeId)
                .HasComment("from A_SystemCode =3")
                .HasColumnName("User_Type_ID");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.IdTableActionNavigation).WithMany(p => p.TableActionLogs)
                .HasForeignKey(d => d.IdTableAction)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Table_Action_Log_A_AttachmentTableName");
        });

        modelBuilder.Entity<TableActionLogCheckRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Table_Ac__3214EC27772B205F");

            entity.ToTable("Table_Action_Log_CheckRequest");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.IdTableAction).HasColumnName("ID_Table_Action");
            entity.Property(e => e.IdTableActionValue).HasColumnName("ID_TableActionValue");
            entity.Property(e => e.ImCheckRequestId).HasColumnName("Im_CheckRequest_ID");
            entity.Property(e => e.Nots).HasColumnName("NOTS");
            entity.Property(e => e.TypeLogId)
                .HasComment("from A_SystemCode =32")
                .HasColumnName("Type_log_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserTypeId)
                .HasComment("from A_SystemCode =3")
                .HasColumnName("User_Type_ID");

            entity.HasOne(d => d.IdTableActionNavigation).WithMany(p => p.TableActionLogCheckRequests)
                .HasForeignKey(d => d.IdTableAction)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Table_Action_Log_CheckRequest_A_AttachmentTableName");
        });

        modelBuilder.Entity<TableActionLogEx>(entity =>
        {
            entity.ToTable("Table_Action_Log_EX");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ExCheckRequestId).HasColumnName("Ex_CheckRequest_ID");
            entity.Property(e => e.IdTableAction).HasColumnName("ID_Table_Action");
            entity.Property(e => e.IdTableActionValue).HasColumnName("ID_TableActionValue");
            entity.Property(e => e.Nots).HasColumnName("NOTS");
            entity.Property(e => e.TypeLogId)
                .HasComment("from A_SystemCode =32")
                .HasColumnName("Type_log_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserTypeId)
                .HasComment("from A_SystemCode =3")
                .HasColumnName("User_Type_ID");

            entity.HasOne(d => d.IdTableActionNavigation).WithMany(p => p.TableActionLogExes)
                .HasForeignKey(d => d.IdTableAction)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Table_Action_Log_EX_A_AttachmentTableName");
        });

        modelBuilder.Entity<TableActionLogFarm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Table_Action_Log_Farm");

            entity.ToTable("Table_Action_Log_Farm");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.FarmId).HasColumnName("Farm_ID");
            entity.Property(e => e.IdTableAction).HasColumnName("ID_Table_Action");
            entity.Property(e => e.IdTableActionValue).HasColumnName("ID_TableActionValue");
            entity.Property(e => e.Nots)
                .HasMaxLength(100)
                .HasColumnName("NOTS");
            entity.Property(e => e.TypeLogId)
                .HasComment("from A_SystemCode =32")
                .HasColumnName("Type_log_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserTypeId)
                .HasComment("from A_SystemCode =3")
                .HasColumnName("User_Type_ID");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.IdTableActionNavigation).WithMany(p => p.TableActionLogFarms)
                .HasForeignKey(d => d.IdTableAction)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Table_Action_Log_Farm_A_AttachmentTableName");
        });

        modelBuilder.Entity<TableActionLogStation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Table_Action_Log_Station");

            entity.ToTable("Table_Action_Log_Station");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.IdTableAction).HasColumnName("ID_Table_Action");
            entity.Property(e => e.IdTableActionValue).HasColumnName("ID_TableActionValue");
            entity.Property(e => e.Nots)
                .HasMaxLength(100)
                .HasColumnName("NOTS");
            entity.Property(e => e.StationId).HasColumnName("Station_ID");
            entity.Property(e => e.TypeLogId)
                .HasComment("from A_SystemCode =32")
                .HasColumnName("Type_log_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserTypeId)
                .HasComment("from A_SystemCode =3")
                .HasColumnName("User_Type_ID");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.IdTableActionNavigation).WithMany(p => p.TableActionLogStations)
                .HasForeignKey(d => d.IdTableAction)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Table_Action_Log_Station_A_AttachmentTableName");
        });

        modelBuilder.Entity<TransportMean>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Transport_Means");

            entity.ToTable("Transport_Mean", tb => tb.HasComment("وسائل النقل"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ArName)
                .HasMaxLength(200)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Ar_Name");
            entity.Property(e => e.EnName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("En_Name");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<TreatmentMainType>(entity =>
        {
            entity.ToTable("TreatmentMainType", tb => tb.HasComment("المعالجة الرئيسية"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ArName)
                .HasMaxLength(200)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Ar_Name");
            entity.Property(e => e.EnName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("En_Name");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<TreatmentMaterial>(entity =>
        {
            entity.ToTable("TreatmentMaterial", tb => tb.HasComment("مادة المعالجة"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ItemId).HasColumnName("Item_ID");
            entity.Property(e => e.TreatmentMethodsId).HasColumnName("TreatmentMethods_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.Item).WithMany(p => p.TreatmentMaterials)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK_TreatmentMaterial_Item");

            entity.HasOne(d => d.TreatmentMethods).WithMany(p => p.TreatmentMaterials)
                .HasForeignKey(d => d.TreatmentMethodsId)
                .HasConstraintName("FK_TreatmentMaterial_TreatmentMethods");
        });

        modelBuilder.Entity<TreatmentMethod>(entity =>
        {
            entity.ToTable(tb => tb.HasComment("طرق المعالجة"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ArName)
                .HasMaxLength(200)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Ar_Name");
            entity.Property(e => e.DescAr).HasColumnName("Desc_Ar");
            entity.Property(e => e.DescEn).HasColumnName("Desc_En");
            entity.Property(e => e.EnName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("En_Name");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.TreatmentTypeId).HasColumnName("TreatmentType_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.TreatmentType).WithMany(p => p.TreatmentMethods)
                .HasForeignKey(d => d.TreatmentTypeId)
                .HasConstraintName("FK_TreatmentMethods_TreatmentType");
        });

        modelBuilder.Entity<TreatmentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_StationTreatmentType");

            entity.ToTable("TreatmentType", tb => tb.HasComment("أنواع معالجات"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ArName)
                .HasMaxLength(200)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Ar_Name");
            entity.Property(e => e.EnName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("En_Name");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.MainTypeId).HasColumnName("MainType_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.MainType).WithMany(p => p.TreatmentTypes)
                .HasForeignKey(d => d.MainTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TreatmentType_TreatmentMainType");
        });

        modelBuilder.Entity<Union>(entity =>
        {
            entity.ToTable("Union", tb => tb.HasComment("الاتحاد "));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ArName)
                .HasMaxLength(150)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Ar_Name");
            entity.Property(e => e.EnName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("En_Name");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<UnionCountry>(entity =>
        {
            entity.ToTable("Union_Country", tb => tb.HasComment("الاتحادات الدولية"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CountryId)
                .HasComment("الدولة")
                .HasColumnName("Country_ID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UnionId)
                .HasComment("الاتحاد")
                .HasColumnName("Union_ID");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.Country).WithMany(p => p.UnionCountries)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Union_Country_Country");

            entity.HasOne(d => d.Union).WithMany(p => p.UnionCountries)
                .HasForeignKey(d => d.UnionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Union_Country_Union");
        });

        modelBuilder.Entity<UnitType>(entity =>
        {
            entity.ToTable("UnitType", tb => tb.HasComment("تبع الوارد"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NameAr)
                .HasMaxLength(200)
                .HasColumnName("Name_Ar");
            entity.Property(e => e.NameEn)
                .HasMaxLength(200)
                .HasColumnName("Name_En");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("USER_TYPE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idsource).HasColumnName("IDSource");
            entity.Property(e => e.Isadmin)
                .HasDefaultValue(false)
                .HasColumnName("ISAdmin");
            entity.Property(e => e.UserDeleteDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Delete_Date");
            entity.Property(e => e.UserDeleteId).HasColumnName("User_Delete_Id");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserType1).HasColumnName("UserType");
            entity.Property(e => e.UserUpdataDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updata_Date");
            entity.Property(e => e.UserUpdataId).HasColumnName("User_Updata_Id");
        });

        modelBuilder.Entity<ViewListImPermissionRequest>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_List_Im_PermissionRequest");

            entity.Property(e => e.ArrivalDate).HasColumnName("Arrival_Date");
            entity.Property(e => e.EndDate).HasColumnName("End_Date");
            entity.Property(e => e.ExportCountryName).HasMaxLength(100);
            entity.Property(e => e.ImCheckRequestId).HasColumnName("Im_CheckRequest_ID");
            entity.Property(e => e.ImPermissionNumber)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("ImPermission_Number");
            entity.Property(e => e.ImPermissionRequestId).HasColumnName("Im_PermissionRequest_ID");
            entity.Property(e => e.ImporterId).HasColumnName("Importer_ID");
            entity.Property(e => e.ImporterTypeId).HasColumnName("ImporterType_Id");
            entity.Property(e => e.ImporterTypeName).HasMaxLength(150);
            entity.Property(e => e.IsPrintAr).HasColumnName("IS_Print_Ar");
            entity.Property(e => e.IsPrintEn).HasColumnName("IS_Print_EN");
            entity.Property(e => e.OperationTypeName)
                .HasMaxLength(50)
                .HasColumnName("operationTypeName");
            entity.Property(e => e.PrintCount).HasColumnName("Print_Count");
            entity.Property(e => e.RenewalStatus).HasColumnName("Renewal_Status");
            entity.Property(e => e.ShortName).HasColumnName("shortName");
            entity.Property(e => e.StartDate).HasColumnName("Start_Date");
        });

        modelBuilder.Entity<Village>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_LK_Village");

            entity.ToTable("Village", tb => tb.HasComment("القرية"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ArName)
                .HasMaxLength(200)
                .HasComment("الاسم بالعربية")
                .HasColumnName("Ar_Name");
            entity.Property(e => e.CenterId)
                .HasComment("المركز")
                .HasColumnName("Center_ID");
            entity.Property(e => e.EnName)
                .HasMaxLength(200)
                .HasComment("الاسم بالانجليزية")
                .HasColumnName("En_Name");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");

            entity.HasOne(d => d.Center).WithMany(p => p.Villages)
                .HasForeignKey(d => d.CenterId)
                .HasConstraintName("FK_Village_Center");
        });

        modelBuilder.Entity<VwImFumigationCompletedLot>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Im_Fumigation_CompletedLots");

            entity.Property(e => e.FinalLotResultId).HasColumnName("Final_Lot_Result_ID");
            entity.Property(e => e.FumigationId).HasColumnName("Fumigation_ID");
            entity.Property(e => e.LotId).HasColumnName("Lot_ID");
            entity.Property(e => e.LotNumber)
                .HasMaxLength(50)
                .HasColumnName("Lot_Number");
            entity.Property(e => e.RequestId).HasColumnName("Request_Id");
        });

        modelBuilder.Entity<VwImFumigationDistributionMessageAccess>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Im_Fumigation_DistributionMessageAccess");

            entity.Property(e => e.CheckRequestNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CheckRequest_Number");
            entity.Property(e => e.DistributionId).HasColumnName("Distribution_ID");
            entity.Property(e => e.FumigationId).HasColumnName("Fumigation_ID");
            entity.Property(e => e.SupervisorUserId).HasColumnName("Supervisor_User_ID");
        });

        modelBuilder.Entity<VwImFumigationRequestMetadatum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Im_Fumigation_RequestMetadata");

            entity.Property(e => e.FumigationId).HasColumnName("Fumigation_ID");
            entity.Property(e => e.InspectionRequestAction).HasMaxLength(1000);
            entity.Property(e => e.InspectionRequestCount).HasMaxLength(100);
            entity.Property(e => e.InspectionRequestHoldReason).HasMaxLength(1000);
            entity.Property(e => e.InspectionRequestOrigin).HasMaxLength(100);
            entity.Property(e => e.InspectionRequestVesselTrip).HasMaxLength(263);
        });

        modelBuilder.Entity<WebsiteTypeDetail>(entity =>
        {
            entity.ToTable("WebsiteTypeDetail");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.DescAr).HasColumnName("descAr");
            entity.Property(e => e.DescEn).HasColumnName("descEn");
            entity.Property(e => e.Filepath).HasColumnName("filepath");
            entity.Property(e => e.LinkUrl).HasColumnName("linkURL");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Creation_Date");
            entity.Property(e => e.UserCreationId).HasColumnName("User_Creation_Id");
            entity.Property(e => e.UserDeletionDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Deletion_Date");
            entity.Property(e => e.UserDeletionId).HasColumnName("User_Deletion_Id");
            entity.Property(e => e.UserUpdationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("User_Updation_Date");
            entity.Property(e => e.UserUpdationId).HasColumnName("User_Updation_Id");
            entity.Property(e => e.WebsitetypeId).HasColumnName("WebsitetypeID");

            entity.HasOne(d => d.Websitetype).WithMany(p => p.WebsiteTypeDetails)
                .HasForeignKey(d => d.WebsitetypeId)
                .HasConstraintName("FK_WebsiteTypeDetail_Websitetype");
        });

        modelBuilder.Entity<Websitetype>(entity =>
        {
            entity.ToTable("Websitetype");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.TypeEn).HasColumnName("TypeEN");
        });
        modelBuilder.HasSequence("A__plant_Error_Save_SEQ")
            .StartsAt(15031L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("A__User_Login_SEQ")
            .StartsAt(327878L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("A_AttachmentData_Ex_CheckRequest_SEQ")
            .StartsAt(480L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("A_AttachmentData_Ex_CommitteeResult_Infection_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("A_AttachmentData_Im_CommitteeResult_Infection_SEQ")
            .StartsAt(21621L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("A_AttachmentData_SEQ")
            .StartsAt(672638L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("A_AttachmentData_Station_SEQ")
            .StartsAt(2387L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<short>("A_AttachmentTableName_SEQ")
            .StartsAt(27L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<short>("A_AttachmentTableType_SEQ")
            .StartsAt(31L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("A_SystemCode_SEQ")
            .StartsAt(142L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("A_SystemCodeType_SEQ")
            .StartsAt(34L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("AnalysisLab_SEQ")
            .StartsAt(13L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("AnalysisLabType_SEQ")
            .StartsAt(23L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("AnalysisType_SEQ")
            .StartsAt(22L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Andriod_Location_SEQ")
            .StartsAt(442871L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("Andriod_Operation_SEQ")
            .StartsAt(23L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("Biological_Phase_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<short>("Center_SEQ")
            .StartsAt(324L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("CommitteeEmployee_SEQ")
            .StartsAt(155218L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("CommitteeResultType_SEQ")
            .StartsAt(9L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("CommitteeType_SEQ")
            .StartsAt(15L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Company_National_SEQ")
            .StartsAt(32288L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("CompanyAccreditation_Committee_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("CompanyAccreditation_Payment_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("CompanyAccreditation_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("CompanyActivity_SEQ")
            .StartsAt(35829L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("CompanyActivityType_SEQ")
            .StartsAt(8L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("ContactType_SEQ")
            .StartsAt(9L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("Continents_SEQ")
            .StartsAt(12L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<short>("Country_SEQ")
            .StartsAt(235L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("Enrollment_type_SEQ")
            .StartsAt(9L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_CertificateAddtion_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_CertificateAddtionUser_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("Ex_CertificatesNewCountry_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_CertificatesRequests_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_CertificatesRequestsFiles_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_CertificatesRequestsLotData_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_CertificatesRequestsPayments_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_CertificatesRequestsPaymentsDetailes_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("Ex_CertificatesRequestsPaymentsType_SEQ")
            .StartsAt(8L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("Ex_CheckRequest_Customs_Message_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_CheckRequest_Data_SEQ")
            .StartsAt(22609L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_CheckRequest_Fees_SEQ")
            .StartsAt(22214L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_CheckRequest_Final_Result_SEQ")
            .StartsAt(24567L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_CheckRequest_Items_Lot_Category_SEQ")
            .StartsAt(83664L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_CheckRequest_Items_Lot_Result_SEQ")
            .StartsAt(76995L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_CheckRequest_Items_SEQ")
            .StartsAt(46667L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("Ex_CheckRequest_Lot_Result_Status_SEQ")
            .StartsAt(12L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_CheckRequest_Organization_Distribution_Detials_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_CheckRequest_Organization_Distribution_Master_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_CheckRequest_Organization_Distribution_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_CheckRequest_Places_SEQ")
            .StartsAt(22611L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("Ex_CheckRequest_Port_SEQ")
            .StartsAt(54563L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_CheckRequest_RefuseReason_SEQ")
            .StartsAt(180L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_CheckRequest_SampleData_Confirm_SEQ")
            .StartsAt(954L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_CheckRequest_SampleData_SEQ")
            .StartsAt(2330L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_CheckRequest_SEQ")
            .StartsAt(22614L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_CheckRequest_Visa_SEQ")
            .StartsAt(21281L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_CheckRequestData_Extra_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_CheckRequset_Shipping_Method_SEQ")
            .StartsAt(38918L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("EX_Choose_SampleData_SEQ")
            .StartsAt(2067L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("EX_Choose_Treatment_SEQ")
            .StartsAt(262L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("Ex_CommitteeCheckLocation_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_CommitteeResult_Confirm_SEQ")
            .StartsAt(34054L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_CommitteeResult_Infection_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_CommitteeResult_SEQ")
            .StartsAt(91259L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("EX_Constrain_Country_Item_SEQ")
            .StartsAt(54L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("EX_Constrain_Text_SEQ")
            .StartsAt(185L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("EX_Constrain_Type_SEQ")
            .StartsAt(13L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_ContactData_SEQ")
            .StartsAt(77423L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_CountryConstrain_AnalysisLabType_SEQ")
            .StartsAt(154L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_CountryConstrain_ArrivalPort_SEQ")
            .StartsAt(5L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_CountryConstrain_SEQ")
            .StartsAt(1596L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_CountryConstrain_Text_SEQ")
            .StartsAt(5568L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_CountryConstrain_Treatment_SEQ")
            .StartsAt(245L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("EX_Fees_Type_SEQ")
            .StartsAt(8L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("Ex_Final_Result_SEQ")
            .StartsAt(19L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("Ex_OpertaionType_SEQ")
            .StartsAt(4L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_Request_TreatmentData_Confirm_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_Request_TreatmentData_SEQ")
            .StartsAt(25L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_RequestCommittee_Fees_ENG_SEQ")
            .StartsAt(6813L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_RequestCommittee_SEQ")
            .StartsAt(37424L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_RequestCommittee_Shift_SEQ")
            .StartsAt(22811L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Ex_Visa_SEQ")
            .StartsAt(3L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("Family_SEQ")
            .StartsAt(2507L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Farm_CheckList_SEQ")
            .StartsAt(24L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Farm_Committee_CheckList_Confirm_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Farm_Committee_CheckList_SEQ")
            .StartsAt(11761L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Farm_Committee_Constrain_SEQ")
            .StartsAt(16196L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Farm_Committee_Examination_Confirm_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Farm_Committee_Examination_SEQ")
            .StartsAt(71L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Farm_Committee_Final_Result_SEQ")
            .StartsAt(6L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Farm_Committee_SEQ")
            .StartsAt(57L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Farm_Committee_Shift_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Farm_Company_SEQ")
            .StartsAt(403L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Farm_Constrain_SEQ")
            .StartsAt(3337L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Farm_Constrain_Text_SEQ")
            .StartsAt(27L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Farm_Country_CheckList_SEQ")
            .StartsAt(1975L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Farm_Country_SEQ")
            .StartsAt(33162L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("Farm_Fees_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Farm_ItemCategories_SEQ")
            .StartsAt(608L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Farm_Request_ItemCategories_SEQ")
            .StartsAt(500L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Farm_Request_Refuse_Reason_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Farm_Request_SEQ")
            .StartsAt(436L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("Farm_Request_Type_SEQ")
            .StartsAt(7L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Farm_SampleData_Confirm_Item_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Farm_SampleData_Confirm_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Farm_SampleData_Item_SEQ")
            .StartsAt(7L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Farm_SampleData_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Farms_Organization_Distribution_Detials_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Farms_Organization_Distribution_Master_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("FarmsData_SEQ")
            .StartsAt(349L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("FarmStop_SEQ")
            .StartsAt(194L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Fees_Action_SEQ")
            .StartsAt(2518L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Fees_Altahsil_Detiles_SEQ")
            .StartsAt(90L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Fees_Altahsil_SEQ")
            .StartsAt(56L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Fees_Certificates_Payment_Detiles_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("Fees_Money_SEQ")
            .StartsAt(6L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("Fees_process_SEQ")
            .StartsAt(6L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<short>("Fees_TableName_SEQ")
            .StartsAt(11L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Fees_Transactions_Detiles_SEQ")
            .StartsAt(304530L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Fees_Transactions_Payment_Detiles_SEQ")
            .StartsAt(4664L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Fees_Transactions_SEQ")
            .StartsAt(266484L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("Fees_Type_Action_SEQ")
            .StartsAt(14L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("FeesAmount_Fixed_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("FeesType_SEQ")
            .StartsAt(36L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("FreeZone_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("FumigationUnit_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Gas_ImportCompany_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("General_Admin_SEQ")
            .StartsAt(63L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<short>("Governate_SEQ")
            .StartsAt(36L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("Group_SEQ")
            .StartsAt(100L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("HagrContact_SEQ")
            .StartsAt(11L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("Im_CheckRequest_Customs_Message_SEQ")
            .StartsAt(319957L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_CheckRequest_Data_SEQ")
            .StartsAt(325993L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_CheckRequest_Distribution_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_CheckRequest_Final_Result_SEQ")
            .StartsAt(128485L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_CheckRequest_Items_Lot_Category_SEQ")
            .StartsAt(627556L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_CheckRequest_Items_Lot_Result_SEQ")
            .StartsAt(161452L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_CheckRequest_Items_SEQ")
            .StartsAt(577898L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("Im_CheckRequest_Lot_Result_Status_SEQ")
            .StartsAt(7L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_CheckRequest_Manafest_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("Im_CheckRequest_Port_SEQ")
            .StartsAt(669453L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_CheckRequest_RefuseReason_SEQ")
            .StartsAt(49002L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_CheckRequest_SampleData_Confirm_SEQ")
            .StartsAt(10438L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_CheckRequest_SampleData_SEQ")
            .StartsAt(14555L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_CheckRequest_SEQ")
            .StartsAt(326067L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_CheckRequest_Visa_SEQ")
            .StartsAt(122089L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_CheckRequestData_Extra_SEQ")
            .StartsAt(322593L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_CheckRequset_Shipping_Method_SEQ")
            .StartsAt(535065L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("Im_Committee_CustodyPlace_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("Im_CommitteeCheckLocation_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_CommitteeResult_Confirm_SEQ")
            .StartsAt(34768L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_CommitteeResult_Infection_SEQ")
            .StartsAt(72L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_CommitteeResult_SEQ")
            .StartsAt(206132L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_Constrain_Initiator_Text_SEQ")
            .StartsAt(73225L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("Im_Constrain_Type_SEQ")
            .StartsAt(71L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_Constrains_Special_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_CountryConstrain_ArrivalPort_SEQ")
            .StartsAt(9L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_CountryConstrain_Text_SEQ")
            .StartsAt(167L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_CustodyPlace_CheckRequest_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_CustodyPlace_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("Im_CustodyPlaceType_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_Execution_Items_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_Execution_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("Im_Final_Result_SEQ")
            .StartsAt(9L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_Fumigation_Distribution_Inspection_SEQ");
        modelBuilder.HasSequence("Im_Fumigation_Distribution_Result_SEQ");
        modelBuilder.HasSequence("Im_Fumigation_Distribution_SEQ");
        modelBuilder.HasSequence("Im_Fumigation_Release_Request_SEQ");
        modelBuilder.HasSequence("Im_Initiator_SEQ")
            .StartsAt(129667L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_ItemsLotDivision_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_Manafest_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("Im_OpertaionType_SEQ")
            .StartsAt(17L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_PermissionItem_Division_Custody_DismissCommittee_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_PermissionItem_Division_Custody_ReceiveCommittee_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_PermissionItem_Division_Custody_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_PermissionItems_Category_SEQ")
            .StartsAt(4889L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_PermissionItems_SEQ")
            .StartsAt(457222L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_PermissionRequest_RefuseReason_SEQ")
            .StartsAt(2267L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_PermissionRequest_SEQ")
            .StartsAt(476905L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("Im_ProcedureType_SEQ")
            .StartsAt(9L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("Im_Request_Port_SEQ")
            .StartsAt(914070L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_Request_TreatmentData_Confirm_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_Request_TreatmentData_SEQ")
            .StartsAt(11391L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_RequestCommittee_Procedure_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_RequestCommittee_SEQ")
            .StartsAt(155219L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_RequestCommittee_Shift_SEQ")
            .StartsAt(162062L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_RequestDat_Extra_SEQ")
            .StartsAt(457361L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_RequestData_SEQ")
            .StartsAt(457236L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_ScientificResearch_ItemPlant_Inseket_Lieble_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_ScientificResearch_ItemPlant_Product_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_ScientificResearch_Organization_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_ScientificResearch_Person_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_ScientificResearch_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("Im_Stores_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_SubDivission_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("Im_TransUnderCustodyReason_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Im_Visa_SEQ")
            .StartsAt(11L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("Im_Warehouses_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("InternationalTransportation_SEQ")
            .StartsAt(9639L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("Item_Purpose_SEQ")
            .StartsAt(39L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Item_SEQ")
            .StartsAt(3284L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Item_ShortName_SEQ")
            .StartsAt(2114L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("Item_Status_SEQ")
            .StartsAt(66L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("Item_Type_SEQ")
            .StartsAt(7L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("ItemCategories_Group_SEQ")
            .StartsAt(170L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("ItemCategories_SEQ")
            .StartsAt(9195L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<short>("ItemCategories_Type_SEQ")
            .StartsAt(6L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("ItemPart_SEQ")
            .StartsAt(2755L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("Kingdom_SEQ")
            .StartsAt(16L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("Level_SEQ")
            .StartsAt(12L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("LiableItems_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("LiableItems_ShortName_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("LiableItems_Status_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("MainCalssification_SEQ")
            .StartsAt(23L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("Order_SEQ")
            .StartsAt(447L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Outlet_Employee_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Outlet_SEQ")
            .StartsAt(245L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<short>("Package_Material_SEQ")
            .StartsAt(12L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<short>("Package_Type_SEQ")
            .StartsAt(21L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Pallet_Data_Ex_CheckRequest_Distribution_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Pallet_Data_Organization__Distribution_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Person_SEQ")
            .StartsAt(1191L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("PhylumSubphylum_SEQ")
            .StartsAt(74L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("Port_International_SEQ")
            .StartsAt(22930L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("Port_Type_SEQ")
            .StartsAt(6L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("PortNational_SEQ")
            .StartsAt(35L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("PortOrganization_SEQ")
            .StartsAt(5L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("pos_information_SEQ")
            .StartsAt(32L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Public_Organization_SEQ")
            .StartsAt(704L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("PublicOrganization_Type_SEQ")
            .StartsAt(8L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<short>("QualitativeGroup_SEQ")
            .StartsAt(60L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<short>("Refuse_Reason_SEQ")
            .StartsAt(8L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("Regional_Area_SEQ")
            .StartsAt(27L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Regions_SEQ")
            .StartsAt(59L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("SecondaryClassification_SEQ")
            .StartsAt(38L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("ShiftTiming_SEQ")
            .StartsAt(10L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("Shipment_Mean_SEQ")
            .StartsAt(9L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("ShippingAgencies_SEQ")
            .StartsAt(484L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("ShippingCompanies_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Station_Accreditation_CheckList_SEQ")
            .StartsAt(472L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Station_Accreditation_Committee_CheckList_Confirm_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Station_Accreditation_Committee_CheckList_SEQ")
            .StartsAt(22758L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Station_Accreditation_Committee_Final_Result_SEQ")
            .StartsAt(813L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Station_Accreditation_Committee_Imge_SEQ")
            .StartsAt(903L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Station_Accreditation_Committee_SEQ")
            .StartsAt(1244L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Station_Accreditation_Committee_Shift_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Station_Accreditation_Data_Country_SEQ")
            .StartsAt(4340L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Station_Accreditation_Data_Item_ShortName_SEQ")
            .StartsAt(85L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Station_Accreditation_Data_SEQ")
            .StartsAt(39L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Station_Accreditation_Request_Fees_ENG_SEQ")
            .StartsAt(5L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Station_Accreditation_Request_Fees_SEQ")
            .StartsAt(904L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Station_Accreditation_Request_SEQ")
            .StartsAt(1376L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("Station_Accreditation_Request_Type_SEQ")
            .StartsAt(4L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Station_Accreditation_SEQ")
            .StartsAt(600L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Station_CheckList_SEQ")
            .StartsAt(164L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("Station_Constrain_Country_Item_SEQ")
            .StartsAt(17L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("Station_Constrain_Type_SEQ")
            .StartsAt(7L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Station_Emp_SEQ")
            .StartsAt(2240L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("Station_Fees_Type_SEQ")
            .StartsAt(8L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Station_Managing_Director_SEQ")
            .StartsAt(995L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Station_SEQ")
            .StartsAt(584L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("StationActivityType_SEQ")
            .StartsAt(6L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("StationCompany_SEQ")
            .StartsAt(618L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("StationContacts_SEQ")
            .StartsAt(670L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("SteamingCompany_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("SubPart_SEQ")
            .StartsAt(127L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("SubPart_Type_SEQ")
            .StartsAt(16L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Table_Action_Log_CheckRequest_SEQ")
            .StartsAt(1812526L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Table_Action_Log_EX_SEQ")
            .StartsAt(18628L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Table_Action_Log_Farm_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Table_Action_Log_SEQ")
            .StartsAt(782104L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence("Table_Action_Log_Station_SEQ")
            .StartsAt(2664L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<short>("Table_Action_SEQ")
            .StartsAt(65L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("Transport_Mean_SEQ")
            .StartsAt(7L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("TreatmentMainType_SEQ")
            .StartsAt(6L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("TreatmentMaterial_SEQ")
            .StartsAt(15L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("TreatmentMethods_SEQ")
            .StartsAt(14L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("TreatmentType_SEQ")
            .StartsAt(8L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<short>("Union_Country_SEQ")
            .StartsAt(92L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<short>("Union_SEQ")
            .StartsAt(11L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<byte>("UnitType_SEQ")
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<short>("Village_SEQ")
            .StartsAt(4411L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("Websitetype_SEQ")
            .StartsAt(17L)
            .HasMin(1L)
            .IsCyclic();
        modelBuilder.HasSequence<int>("WebsiteTypeDetail_SEQ")
            .StartsAt(263L)
            .HasMin(1L)
            .IsCyclic();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
