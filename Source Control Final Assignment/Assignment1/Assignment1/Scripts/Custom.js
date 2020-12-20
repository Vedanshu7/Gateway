(function ($) {
    "use strict";

    // Add active state to sidbar nav links
   
    // Toggle the side navigation
    var a = $(".sidebar"),
        b = $(".navbar"),
        c = $(".rightbar");

    var bOuterHeight = b.outerHeight();

    a.css("margin-top", bOuterHeight);
    c.css("margin-top", bOuterHeight);

    var aMarginBottom = a.css("margin-top");
    $("#navitem").on("click", function (e) {
        e.preventDefault();
        if ($("#userDropdown").attr("aria-expanded") == "true") {
            $("#li").removeClass("show");
            $("#userDropdown").attr("aria-expanded", "false");
            $("#divd").removeClass("show");
        }
        else {
            $("#li").addClass("show");
            $("#userDropdown").attr("aria-expanded", "true");
            $("#divd").addClass("show");
        }
    });
})(jQuery);
