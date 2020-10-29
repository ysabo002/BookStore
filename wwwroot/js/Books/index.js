$(document).ready(function () {
    $('#booksTable').DataTable();
    //initializeBookDataTable();
});

//async function initializeBookDataTable() {

//    var dtBookOptions = {
//        dom: "tp",
//        data: $booksList,
//        responsive: true,
//        ordering: true,
//        paging: true,
//        lenght: [10, 20],
//        language: {
//            lengthMenu: "MENU ",
//            zeroRecords: "No data available",
//            infoEmpty: "No records available",
//            infoFiltered: "(filtered from MAX total records)"
//        },
//        columns: [
//            {
//                data: "ratingAve",
//                class: "text-center",
//                render: function (dataCell, display, dataRow) {
//                    var stars = '';
//                    for (var i = 0; i < dataRow.rate; i++) {
//                        stars += '<span class="fal fa-star"></span>'
//                    }
//                    return stars;

//                },
//            },
//            {
//                data: "id",
//                render: function (dataCell, display, dataRow) {
//                    let div = `<div class="text align:center">
//                                    <button class="btn edit-book" data-action="edit" data-id="`+ dataCell + `"><i class="fal fa-edit float-right link-list-item text-primary edit-book-type"></i></button>
//                                    <button class="btn delete-book" data-action="delete" data-id="`+ dataCell + `"><i class="fal fa-trash float-right link-list-item text-danger delete-book-type"></i></button>
//                                    <button class="btn details-book" data-action="details" data-id="`+ dataCell + `"><i class="fal fa-eye float-right link-list-item text-primary details-book-type"></i></button>
//                                    <button class="btn add-to-cart-book" data-action="add-to-cart" data-id="`+ dataCell + `"><i class="fal fa-cart-plus float-right link-list-item text-primary details-book-type"></i></button>
//                                </div>`
//                    return div;
//                }
//            }
//        ],
//        columnDefs: [
//            {
//                targets: [6],
//                orderable: true
//            },
//        ],
//        createdRow: function (row, data, index) {
//            $(row).attr('id', data['id']);
//            //here add listener to this new node
//            $(document).on('click', '.edit-book, .delete-book, .details-book, add-to-cart-book', function (evet) {
//                event.preventDefault();
//                let bookId = $(this).data("id");

//                switch ($(this).data('action')) {
//                    case 'edit':
//                        window.location.href = '/Book/Edit?bookId=' + bookId;
//                        break;
//                    case 'delete':
//                        window.location.href = '/Book/Delete?bookId=' + bookId;
//                        break;
//                    case 'details':
//                        window.location.href = '/Book/Details?bookId=' + bookId;
//                        break;
//                    case 'add-to-cart':
//                        //window.location.href = '/Book/AddToCart?bookId=' + bookId;
//                        break;
//                }
//            });
//        }
//    };
//    if ($booksList) {
//        $booksList.destroy();
//    }

//    $booksList = $('#booksTable').DataTable(dtBookOptions);

//}