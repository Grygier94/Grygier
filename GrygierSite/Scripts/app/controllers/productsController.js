
var ProductsController = function () {

    var init = function () {
        $(".body-content").on("click", ".nav-pagination a", loadProducts);
    };

    var loadProducts = function () {

        var link = $(this),
        url = link.attr("href");

        $(".body-content").load(url);

        return false;
    }

    return {
        init: init
    }

}();