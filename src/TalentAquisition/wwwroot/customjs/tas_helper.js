var tas_helper = {
    
    notify: function (msg, type) {
        //https://www.jqueryscript.net/other/Highly-Customizable-jQuery-Toast-Message-Plugin-Toastr.html
        if (type == 1) {
            toastr.success(msg, 'Success');

        }if (type == 2) {
            toastr.error(msg, 'Error');

        }if (type == 3) {
            toastr.warning(msg, 'Warning');
        }if (type == 4) {
            toastr.info(msg, 'Info');
        }
    },
    
    isEmail: function (emailAdress) {

        
            let regex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;

            if (emailAdress.match(regex))
                return true;

            else
                return false;
        

    },
    
    dxGridbinding: function (div, columns, datasrc, fileName, selectionMode) {
        const columnChooserModes = [{
            "key": 'dragAndDrop',
            "name": 'Drag and drop',
        }, {
            "key": 'select',
            "name": 'Select',
            }];
        var mode = "single";
        if (selectionMode != '' && selectionMode != null && selectionMode != undefined) {
            mode = selectionMode;
        }
        const dataGrid = $(div).dxDataGrid({
            "dataSource": datasrc,
            "columns": columns,
            "remoteOperations": false,
            "rowAlternationEnabled": true,
            "groupPanel": { visible: true },
            "columnAutoWidth": true,
            "allowColumnResizing": true,
            "headerFilter": {
                "visible": true,
                "search": {
                    "enabled": true,
                    "editorOptions": {
                        "placeholder": 'Search',
                    },
                },
            },
            "paging": {
                "pageSize": 10,
            },
            "pager": {
                "visible": true,
                "allowedPageSizes": [100, 200, 300, 'all'],
                "showPageSizeSelector": true,
                "showInfo": true,
                "showNavigationButtons": true,
            },
            "searchPanel": {
                "visible": true,
                "highlightCaseSensitive": true,
            },
            "filterRow": {
                "visible": true,
                "applyFilter": 'auto',
            },
            "columnChooser": {
                "enabled": true,
                "mode": columnChooserModes[1].key,
                "position": {
                    "my": 'right top',
                    "at": 'right bottom',
                    "of": '.dx-datagrid-column-chooser-button',
                },
                "search": {
                    "enabled": true,
                    "editorOptions": { placeholder: 'Search column' },
                },
                "selection": {
                    "recursive": true,
                    "selectByClick": true,
                    "allowSelectAll": true,
                },
            },
            "scrolling": {
                "mode": "both"
            },
            "columnFixing": {
                "enabled": true,
            },
            "selection": {
                "mode": mode,
            },
            "export": {
                "enabled": true,
                "formats": ['excel', 'pdf'],
                allowExportSelectedData: false,
            },
            onExporting(e) {
                if (e.format === 'pdf') {
                    const doc = new jsPDF({
                        orientation: 'portrait',
                        unit: 'pt',
                        format: 'a1'
                    });

                    DevExpress.pdfExporter.exportDataGrid({
                        jsPDFDocument: doc,
                        component: e.component,
                        indent: 5,
                        selectedRowsOnly: false, // Export all rows
                        margin: {
                            top: 10,
                            right: 10,
                            bottom: 10,
                            left: 10,
                        },
                        topLeft: { x: 5, y: 5 },
                        customizeCell: function (options) {
                            if (options.gridCell.rowType === "data" && options.gridCell.column.caption === "Image") {
                                var img = new Image();
                                img.src = options.gridCell.value;
                                doc.addImage(img, 'PNG', 5, 5, 50, 50);
                                return false;
                            }
                        }
                    }).then(function () {
                        doc.save(fileName + '.pdf');
                    });
                }
                else {
                    const workbook = new ExcelJS.Workbook();
                    const worksheet = workbook.addWorksheet(fileName);

                    DevExpress.excelExporter.exportDataGrid({
                        component: e.component,
                        worksheet,
                        autoFilterEnabled: true,
                        selectedRowsOnly: false // Export all rows
                    }).then(() => {
                        workbook.xlsx.writeBuffer().then((buffer) => {
                            saveAs(new Blob([buffer], { type: 'application/octet-stream' }), fileName + '.xlsx');
                        });
                    });
                }
            },
            onCellPrepared(e) {
                const column = e.column;
                const rowData = e.data;
                const value = rowData && column && column.dataField ? rowData[column.dataField] : null;

                if (column.caption && (column.caption.toLowerCase().includes('date') || column.caption.toLowerCase().includes('exp')) && (value == '1900-01-01' || value == '01-01-1900' || value == '01-Jan-1900' || value == '1/1/1900 12:00:00 AM' || value == '1/1/1900')) {
                    $(e.cellElement).text('')
                }
            },
            summary: {
            }
        }).dxDataGrid('instance');
    },

    isMobile: function () {
        return $(window).width() < 768;
    }
}