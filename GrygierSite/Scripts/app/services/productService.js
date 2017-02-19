
var ProductService = function () {

    var deleteProduct = function (productId, done, fail) {
        $.ajax({
            url: "/api/products/" + productId,
            method: "DELETE"
        })
            .done(done)
            .fail(fail);
    };

    var renderProductsTable = function() {
        $("#products").DataTable({
            ajax: {
                url: "/api/products",
                dataSrc: ""
            },
            columns: [
                {
                    data: "thumbnailPath",
                    orderable: false,
                    render: function (data, type, product) {
                        return "<a href='/products/details/" + product.id + "'><img src='/" + data + "' class='img-responsive'/></a>";
                    }
                },
                {
                    data: "id"
                },
                {
                    data: "name",
                    render: function (data, type, product) {
                        return "<a href='/products/details/" + product.id + "'>" + data + "</a>";
                    }
                },
                {
                    data: "category.name"
                },
                {
                    data: "price",
                    render: function (data) {
                        return "<p>" + data.toFixed(2) + "$</p>";
                    }
                },
                {
                    data: "id",
                    orderable: false,
                    render: function (data) {
                        return "<a href='/products/edit/" + data + "' class='js-edit' data-product-id=" + data + ">Edit</a>";
                    }
                },
                {
                    data: "id",
                    orderable: false,
                    render: function (data) {
                        return "<button class='btn-link js-delete' data-product-id=" + data + ">Delete</button>";
                    }
                }
            ]
        });
    };

    return {
        deleteProduct: deleteProduct,
        renderProductsTable: renderProductsTable
    }
}();