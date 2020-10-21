$(document).ready(function () {
    $('#booksTable').DataTable(

    );
});



function initializeDatatable(dtWithOptions) {
    if (dtWithOptions === undefined) {
        dtWithOptions = {};
    }

    for (let i = 0; i < dtWithOptions.length; i++) {
        let dtId = "#" + dtWithOptions[i].dtId;
        let dtUrl = $(dtId).data("url");
        let dtOptions = dtWithOptions[i].dtOptions;

        let $this = $(dtId);

        if (!$this.length)
            return;

        $this.DataTable().destroy();

        let options = {
            "serverSide": true,
            "ordering": true,
            "deferRender": true,
            "processing": true,
            "scrollX": true,
            //"initComplete": appDatatableInitComplete,
            //"drawCallback": appDatatableDrawCallback,
            "createdRow": function (row, data, index) {
                $(row).attr('id', data[dtOptions.rowId]);
            },
            //"dom": '<"row"<"col-12"rt>><"row justify-content-center" <"col-12"i>><"row view-filter"<"col-12"<"float-left"l><"float-right"p>>>',
            "dom": '<"row"<"float-left"B><"float-right"f>>rt<"row justify-content-center"<"col-md-3 col-12 table-show-entries"l><"col-md-6 col-12"p><"col-md-3 col-12 text-right"i>>',
            "language": {
                "paginate": {
                    "previous": "Prev"
                },
                "lengthMenu": "Show MENU",
                "zeroRecords": "No data available",
                "info": "Showing END of MAX",
                "infoEmpty": "No records available",
                "infoFiltered": "(filtered from MAX total records)"
            }

        };