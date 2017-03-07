
var TagController = function () {

    var tagIterator = 0;
    var tagIds = [];

    var init = function () {
        typeAhead();
        $("ul").on("click", ".js-remove-tag", removeTag);
    };

    var typeAhead = function () {

        var tags = new Bloodhound({
            datumTokenizer: Bloodhound.tokenizers.obj.whitespace("name"),
            queryTokenizer: Bloodhound.tokenizers.whitespace,
            remote: {
                url: "/api/tags/?query=%QUERY",
                wildcard: "%QUERY"
            }
        });

        $("#tag").typeahead({
            highlight: true
        },
               {
                   name: "tags",
                   display: "name",
                   source: tags
               }).on("typeahead:select",
               function (e, tag) {
                   if (tagIterator > 5) {
                       toastr.error("Number of tags can't be higher than 6.");
                   }
                       
                   else if ($.inArray(tag.id, tagIds) !== -1) {
                       toastr.error("Selected tag was already chosen.");
                   }
                   else {

                       $("#tags").append("<li class='list-group-item''>" +
                           tag.name +
                           "<button type='button' id='" + tagIterator + "' class='btn-link pull-right js-remove-tag'>" +
                           "<span class='glyphicon glyphicon-remove' aria-hidden='true'></span>" +
                           "</button></li>");

                       $("#tag-ids").append("<input id='" + tagIterator + "' name='TagIds[" +
                           tagIterator +
                           "]' type='hidden' value='" +
                           tag.id +
                           "'/>");
                       tagIds[tagIterator] = tag.id;
                       tagIterator++;
                   }
                   $("#tag").typeahead("val", "");
               });
    };

    var removeTag = function () {
        var inputToRemove = $(this).attr("id");

        tagIds[tagIds.indexOf(parseInt($("#tag-ids #" + inputToRemove).attr("value")))] = 0;
        $(this).parent().remove();
        $("#" + inputToRemove).remove();

        tagIterator = 0;
        $("#tag-ids").children("input").each(function () {
            $(this).attr("name", "TagIds[" + tagIterator + "]");
            $(this).attr("id", tagIterator);
            tagIterator++;
        });

        tagIterator = 0;
        $("#tags button").each(function () {
            $(this).attr("id", tagIterator);
            tagIterator++;
        });
    }

    return {
        init: init
    }

}();