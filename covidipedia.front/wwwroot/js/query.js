$(document).ready(function() {
    $.noConflict();
    $('#results-table').DataTable({
        language: {
            url: "https://cdn.datatables.net/plug-ins/1.10.22/i18n/French.json"
        }
    })
});