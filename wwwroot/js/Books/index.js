$(document).ready(function () {


    $('#booksTable').DataTable({
        dom: "lftip",
        responsive: true,
        ordering: true,
        order: [[1, "asc"]],
        paging: true,
        lengthMenu: [10, 20, 30, 40, 50],
        language: {
            zeroRecords: "No data available",
            infoEmpty: "No records available",
           
        },
        columnDefs: [
            {
                targets: [7],
                class: "text-center",
                render: function (dataCell, display, dataRow) {
                    var stars = '';
                    for (var i = 0; i < dataCell; i++) {
                        stars += '<span class="fas text-warning fa-star"></span>'
                    }
                    return stars;

                },
            },
            {
                targets: [10],
                render: function (dataCell, display, dataRow) {
                    let div = `<div class="text-center">
                                    <a class="btn edit-book" data-action="edit" href="/Books/Edit/`+ dataCell + `"><i class="fas fa-edit float-right link-list-item text-primary edit-book-type"></i></a>
                                    <a class="btn delete-book" data-action="delete" href="/Books/Delete/`+ dataCell + `"><i class="fas fa-trash float-right link-list-item text-danger delete-book-type"></i></button>
                                    <a class="btn details-book" data-action="details" href="/Books/Details/`+ dataCell + `"><i class="fas fa-eye float-right link-list-item text-primary details-book-type"></i></button>
                                    <a class="btn add-to-cart-book" data-action="add-to-cart" href="#"><i class="fas fa-cart-plus float-right link-list-item text-primary details-book-type"></i></button>
                                </div>`
                    return div;
                }
            }
        ],
        initComplete: function () {
            var table = this.api();
            table.columns().every(function () {
                var column = this;
                var columnIdx = column[0];
                if (columnIdx != 0 && columnIdx != 10) {
                    var select = $('<select style="width:100%"> <option value="">' + column.header().innerText + '</option></select>').appendTo($(column.footer()).empty())
                        .on('change', function () {
                            debugger
                            var value = $.fn.dataTable.util.escapeRegex($(this).val());
                            column.search(value ? '^' + value + '$' : '', true, false).draw();
                        });

                    column.data().unique().sort().each(function (d, j) {
                        select.append('<option value="' + d + '">' + d + '</option>')
                    })
                }
            })
            table.columns.adjust().draw();
        }
    });

});