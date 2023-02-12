(function ($) {
    var _$table = $('#CategoryTable'),
        ;

    var _$categoryTable = _$table.DataTable({
        url: 'https://localhost:7299/api/Categories' +, 
        type: 'GET'
        },
        buttons: [
        {
            name: 'refresh',
            text: '<i class="fas fa-redo-alt"></i>',
            action: () => _$categoryTable.draw(false)
        }
    ],
        responsive: {
        details: {
            type: 'column'
        }
    },
        columnDefs: [
        {
            targets: 0,
            className: 'control',
            defaultContent: '',
        },
        {
            targets: 1,
            data: 'maChucVu',
            sortable: false
        },
        {
            targets: 2,
            data: 'tenChucVu',
            sortable: false
        },
        {
            targets: 3,
            data: 'ghiChu',
            sortable: false
        },
        {
            targets: 4,
            data: 'tenTrangThai',
            sortable: false
        },
        {
            targets: 5,
            data: null,
            sortable: false,
            autoWidth: false,
            defaultContent: '',
            render: (data, type, row, meta) => {
                return [
                    `   <button type="button" class="btn btn-sm bg-warning view-chucvu" data-chucvu-id="${row.id}" data-toggle="modal" data-target="#ChucVuViewModal">`,
                    `       <i class="fas fa-eye"></i> ${l('View')}`,
                    '   </button>',
                    `   <button type="button" class="btn btn-sm bg-secondary edit-chucvu" data-chucvu-id="${row.id}" data-toggle="modal" data-target="#ChucVuEditModal">`,
                    `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                    '   </button>'
                ].join('');
            }
        }
    ])
})(jQuery);
