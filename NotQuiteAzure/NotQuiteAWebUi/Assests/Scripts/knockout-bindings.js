ko.bindingHandlers.fadeVisible = {
    update: function (element, valueAccessor, allBindingsAccessor) {
        var value = valueAccessor();
        var valueUnwrapped = ko.utils.unwrapObservable(value);
        var allBindings = allBindingsAccessor();

        var duration = allBindings.fadeDuration || 150;

        if (valueUnwrapped == true) {
            $(element).fadeIn(duration);
        } else {
            $(element).hide();
        }
    }
};