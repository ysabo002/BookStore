$.fn.BookStoreTableClientSide = function (options) {

    // These are the defaults.
    var settings = $.extend({
        dom: 'lftip',
        processing: true,
        serverSide: false,

    }, options);

    var defaultInitComplete = function () {

        var topRow = $('<div>').addClass('row dataTables_top_row').append($('.dataTables_length').addClass('col-md-6'), $('.dataTables_filter').addClass('col-md-6'))
        $('.dataTables_wrapper table').before(topRow)

        var bottomRow = $('<div>').addClass('row dataTables_bottom_row').append($('.dataTables_info').addClass('col-md-6'), $('.dataTables_paginate').addClass('col-md-6'))
        $('.dataTables_wrapper table').after(bottomRow)

        $('[data-toggle="tooltip"]').tooltip();

    }
    if (options != undefined && options.initComplete != undefined) {
        settings.initComplete = function () {
            defaultInitComplete();
            options.initComplete();
        }
    }
    else settings.initComplete = defaultInitComplete;

    this.addClass('table table-hover table-sm')
    this.css({
        width: '100%'
    })

    return this.DataTable(settings);


}