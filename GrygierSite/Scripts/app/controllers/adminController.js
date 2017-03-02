
var AdminController = function (productService) {

    var init = function () {
        $("#products").on("click", ".js-delete", deleteProduct);
        $(".js-delete-product").click(deleteProduct);
    };

    var deleteProduct = function () {

        var link = $(this);
        var showDialogBox = function() {
            bootbox.confirm({
                title: "Delete",
                message: "Are you sure you want to delete the product?",
                buttons: {
                    confirm: {
                        label: 'Delete',
                        className: 'btn-danger'
                    },
                    cancel: {
                        label: 'Cancel',
                        className: 'btn-default'
                    }
                },
                callback: function(result) {
                    if (result) {
                        var productId = link.attr("data-product-id");
                        productService.deleteProduct(productId, done, fail);
                    }
                }
            });
        }();

        var done = function() {
            toastr.success("Product successfully deleted.");
            if (window.location.href.indexOf("Admin/Dashboard") === -1) {
                window.location.href = "/home/index";
            } else {
                link.parents("tr").fadeOut(function () {
                    (this).remove();
                });
            }
        };

        var fail = function() {
            toastr.error("Something unexpected happend.");
        };
    }

    return {
        init: init
    }

}(ProductService);