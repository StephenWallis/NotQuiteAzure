var AMI = {};

/*** Url Helper ***/
AMI.urlHelper = {
    baseURI: undefined,
    resolve: function (url) {
        if (this.baseURI === undefined)
        { throw "AMI.urlHelper.baseURI not defined"; }

        return url.replace(/~\//gi, this.baseURI);
    },
    variant: function (vehicleKey) {
        return this.resolve("~/api/variant/" + vehicleKey);
    },
    postVariant: function () {
        return this.resolve("~/api/variant/");
    },
    make: function () {
        return this.resolve("~/api/make");
    },
    model: function (make) {
        return this.resolve("~/api/model/" + make);
    },
    bodyStyle: function () {
        return this.resolve("~/api/bodyStyle");
    },
    transmissionType: function () {
        return this.resolve("~/api/transmissionType");
    },
    driveType: function () {
        return this.resolve("~/api/driveType");
    },
    fuelType: function () {
        return this.resolve("~/api/fuelType");
    },
    family: function () {
        return this.resolve("~/api/family");
    },
    familyByCode: function (familyCode) {
        return this.resolve("~/api/family/" + familyCode);
    },
    familyByName: function (familyName) {
        return this.resolve("~/api/familyCode/" + familyName);
    },
    risk: function (family) {
        return this.resolve("~/api/risk/" + family);
    },
    history: function (vehicleKey) {
        return this.resolve("~/api/history/" + vehicleKey);
    },
    quarantine: function () {
        return this.resolve("~/api/quarantine/");
    },
    quarantineTextByStatusCode: function (statusCode) {
        return this.resolve("~/api/quarantineReason/" + statusCode);
    },
    quarantineValidationReasons: function () {
        return this.resolve("~/api/quarantineReason");
    },
    quarantineMake: function () {
        return this.resolve("~/api/quarantineMake/");
    },
    quarantineModel: function () {
        return this.resolve("~/api/quarantineModel/");
    },
    checkValidation: function () {
        return this.resolve("~/api/validatevariant/");
    },
    postQuarantineResults: function () {
        return this.resolve("~/api/quarantine/");
    },
    postQuarantineImport: function () {
        return this.resolve("~/api/quarantineImport/");
    },
    lastQuarantineRunDate: function () {
        return this.resolve("~/api/lastQuarantineRun");
    },
    allMakeObjects: function () {
        return this.resolve("~/api/reference/makes");
    },
    allModelObjectsForMake: function (make) {
        return this.resolve("~/api/reference/models/" + make);
    },
    postMakeObject: function () {
        return this.resolve("~/api/reference/make");
    },
    postModelObject: function () {
        return this.resolve("~/api/reference/model");
    },
    ratingRiskLevels: function () {
        return this.resolve("~/api/reference/ratingrisklevels");
    },
    ratingRiskLevel: function () {
        return this.resolve("~/api/reference/ratingrisklevel");
    },
    deleteRatingRiskLevel: function (id) {
        return this.resolve("~/api/reference/deleteratingrisklevel/" + id);
    },
    duplicaterisklevel: function () {
        return this.resolve("~/api/reference/duplicaterisklevel/");
    },
    categories: function () {
        return this.resolve("~/api/category/");
    },
    category: function () {
        return this.resolve("~/api/category/create/");
    },
    deleteCategory: function (id) {
        return this.resolve("~/api/category/delete/" + id);
    },
    duplicateCategory: function () {
        return this.resolve("~/api/category/duplicate/");
    }
};

/*** View Model Initialisation ***/
AMI.applyViewModel = function (selector, createViewModel) {
    $(selector).each(function () {
        var viewModel = createViewModel(this);
        $(this).data('viewModel', viewModel);
        ko.applyBindings(viewModel, this);
    });
};

/*** Resources ***/
AMI.resources = (function () {
    this.toDateString = function (value) {
        if (value === undefined) {
            return undefined;
        }
        var date = value;
        if (value !== Date) {
            date = new Date(Date.parse(value));
        }
        return date.format("dd-mm-yyyy");
    };
    this.toTimeString = function(value) {
        if (value === undefined) {
            return undefined;
        }
        var date = value;
        if (value !== Date) {
            date = new Date(Date.parse(value));
        }
        return date.format("HH:MM");
    };
    return this;
})();

