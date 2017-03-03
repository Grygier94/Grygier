
var SubscriberController = function (subscriptionService) {

    var init = function () {
        $("#submit-subscribe").click(subscribe);
    };

    //TODO: Implement validation for subscription form
    var subscribe = function (e) {
        e.preventDefault();

        var subscriber = {
            name: $("input.js-name").val(),
            email: $("input.js-email").val()
        };

        subscriptionService.addSubscriber(subscriber, done, fail);
    };

    var done = function () {
        toastr.success("Subscription successfull.");
        $(".footer-top form")
            .html("<h3>Subscription</h3><p>Thank you for subscribing to our newsletter!</p>");
    };
    var fail = function (xhr, textStatus, errorThrown) {
        if (xhr.status === 409)
            $(".footer-top form")
                .html("<h3>Subscription</h3><p>You already subscribe to our newsletter! Thank you!</p>");
        else {
            $(".footer-top form")
                .html("<h3>Subscription</h3><p>Something unexpected happend. Try again later.</p>");
            toastr.error("Something unexpected happend.");
        }
    };

    return {
        init: init
    }

}(SubscriptionService);