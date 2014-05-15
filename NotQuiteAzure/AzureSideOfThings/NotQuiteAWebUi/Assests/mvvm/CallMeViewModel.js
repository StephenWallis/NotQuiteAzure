;
AMI.CallMeViewModel = function() {
    // data 
    var self = this;

    self.callMeRecords = ko.observableArray();

    // Initial load function; loads the dropdown list of validation reasons
    self.init = function () {
        self.loadCallMeRecords();
    };

    self.loadCallMeRecords = function() {
        //TODO Make the call to webservice.
        // TODO iterate records from web service
        
        self.callMeRecords.push(new AMI.CallMeViewModel.CallMeRecord());
    };

    self.init();
};

AMI.CallMeViewModel.CallMeRecord = function (data) {
    var self = this;

    //self.name = ko.observable(data.Name);
    //self.address = ko.observable(data.Address);
    //self.dob = ko.observable(data.DateOfBirth);
    //self.homePhone = ko.observable(data.HomePhone);
    //self.phoneNumber = ko.observable(data.PhoneNumber);
    //self.customerNumber = ko.observable(data.CustomerNumebr);

    self.name = ko.observable("Wally Noone");
    self.address = ko.observable("113 Main Street, Maintown");
    self.dob = ko.observable("01/01/1980");
    self.homePhone = ko.observable("(555) 555 5555");
    self.phoneNumber = ko.observable("022 222 2222");
    self.customerNumber = ko.observable("123456789");
    
};