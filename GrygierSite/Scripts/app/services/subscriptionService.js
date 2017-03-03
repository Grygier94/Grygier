
var SubscriptionService = function () {

    var addSubscriber = function (subscriber, done, fail) {
        $.post("/api/subscriptions", { name: subscriber.name, email: subscriber.email })
            .done(done)
            .fail(fail);
    };

    return {
        addSubscriber: addSubscriber
    }
}();