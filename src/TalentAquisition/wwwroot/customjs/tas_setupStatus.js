var tas_setupStatus = {
    deleteId: null,

    init: function () {
        this.initializeGrid();
        this.bindEvents();
    },

    initializeGrid: function () {
        tas_ajaxHelper.get(`/SetupStatus/GetAll`, (data) => {
            this.createGrid(data)
        });
    },

    createGrid(dataSrc) {
        var col = [
            {
                dataField: 'name',
                caption: 'Name',
                dataType: 'string'
            },
            {
                dataField: "statusId",
                caption: "Actions",
                width: 100,
                alignment: 'center',
                allowFiltering: false,
                allowSorting: false,
                cellTemplate: (container, options) => {
                    const statusId = options.data.statusId;
                    const $container = $(container);

                    // Create button container
                    const $btnGroup = $('<div class="btn-group btn-group-sm"></div>');

                    // Edit button
                    const $editBtn = $(`
                        <button class="btn btn-sm grid-action-icon elm_edit" 
                                title="Edit" data-id="${statusId}">
                            <i class="fas fa-edit"></i>
                        </button>
                    `).click(() => this.handleEditClick(statusId));

                    // Delete button
                    const $deleteBtn = $(`
                        <button class="btn btn-sm grid-action-icon elm_delete" 
                                title="Delete" data-id="${statusId}">
                            <i class="fas fa-trash"></i>
                        </button>
                    `).click(() => this.handleDeleteClick(statusId));

                    // Append buttons to container
                    $btnGroup.append($editBtn, $deleteBtn);
                    $container.append($btnGroup);
                }
            }
        ];
        this.grid = tas_helper.dxGridbinding('#gridContainer', col, dataSrc, "StatusList");
    },

    bindEvents: function () {
        // Create button click
        $('[data-bs-target="#upsertModal"]').click(this.showCreateModal.bind(this));

        // Edit button click
        $('#statusTable').on('click', '.edit-btn', this.handleEditClick.bind(this));

        // Save button click
        $('#saveBtn').click(this.handleSaveClick.bind(this));

        // Delete button click
        $('#statusTable').on('click', '.delete-btn', this.handleDeleteClick.bind(this));
    },

    showCreateModal: function () {
        $('#statusForm')[0].reset();
        $('#statusId').val(0);
        $('#modalTitle').text('Add Status');
        $('#statusForm').removeClass('was-validated');
    },

    handleEditClick: function (statusId) {
        tas_ajaxHelper.get(`/SetupStatus/GetById/${statusId}`, (data) => {
            $('#statusId').val(data.statusId);
            $('#statusName').val(data.name);
            $('#modalTitle').text('Edit Status');
            $('#upsertModal').modal('show');
        });
    },

    handleSaveClick: function () {
        var form = $('#statusForm')[0];
        if (!form.checkValidity()) {
            form.classList.add('was-validated');
            return;
        }

        var status = {
            StatusId: $('#statusId').val(),
            Name: $('#statusName').val()
        };

        var url = status.StatusId == 0 ? '/SetupStatus/Create' : '/SetupStatus/Edit';
        var method = status.StatusId == 0 ? 'post' : 'put';

        tas_ajaxHelper[method](url, status, () => {
            $('#upsertModal').modal('hide');
            this.initializeGrid();
        });
    },

    handleDeleteClick: function (statusId) {
        if (confirm('Are you sure you want to delete this status?')) {
            tas_ajaxHelper.delete(`/SetupStatus/Delete/${statusId}`, () => {
                this.initializeGrid();
            });
        }
    }
};

$(document).ready(function () {
    tas_setupStatus.init();
});