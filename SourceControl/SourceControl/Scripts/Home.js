/* File Created: January 16, 2012 */


// Value is the element to be validated, params is the array of name/value pairs of the parameters extracted from the HTML, element is the HTML element that the validator is attached to
jQuery(document).ready(function () {
    $.validator.addMethod("customage", function (value, element, params) {
        
        return (new Date().getFullYear() - new Date(value).getFullYear()) > 18;
    });
    $.validator.unobtrusive.adapters.add("customage", function (options) {
        options.rules["customage"] = "#Age";
        options.messages["customage"] = options.message;
    });
});