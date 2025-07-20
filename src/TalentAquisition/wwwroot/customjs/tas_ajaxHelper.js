var tas_ajaxHelper = {
    // Default AJAX settings
    defaults: {
        contentType: "application/json",
        dataType: "json",
        timeout: 10000 // 10 seconds
    },

    // Standard success handler
    handleSuccess: function (response, callback) {
        if (response.success) {
            if (callback) callback(response.data);
            if (response.message) {
                tas_helper.notify(response.message, 1); // Success notification
            }
        } else {
            this.handleError(response.message || "Operation failed");
        }
    },

    // Standard error handler
    handleError: function (error) {
        let errorMsg = "An error occurred";

        if (typeof error === "string") {
            errorMsg = error;
        } else if (error.responseJSON && error.responseJSON.message) {
            errorMsg = error.responseJSON.message;
        } else if (error.statusText) {
            errorMsg = `${error.status}: ${error.statusText}`;
        }

        tas_helper.notify(errorMsg, 3); // Error notification
        console.error("AJAX Error:", error);
    },

    // Make GET request
    get: function (url, callback, options = {}) {
        return $.ajax({
            ...this.defaults,
            ...options,
            url: url,
            type: "GET",
            success: (response) => this.handleSuccess(response, callback),
            error: this.handleError.bind(this)
        });
    },

    // Make POST request
    post: function (url, data, callback, options = {}) {
        return $.ajax({
            ...this.defaults,
            ...options,
            url: url,
            type: "POST",
            data: JSON.stringify(data),
            success: (response) => this.handleSuccess(response, callback),
            error: this.handleError.bind(this)
        });
    },

    // Make PUT request
    put: function (url, data, callback, options = {}) {
        return $.ajax({
            ...this.defaults,
            ...options,
            url: url,
            type: "PUT",
            data: JSON.stringify(data),
            success: (response) => this.handleSuccess(response, callback),
            error: this.handleError.bind(this)
        });
    },

    // Make DELETE request
    delete: function (url, callback, options = {}) {
        return $.ajax({
            ...this.defaults,
            ...options,
            url: url,
            type: "DELETE",
            success: (response) => this.handleSuccess(response, callback),
            error: this.handleError.bind(this)
        });
    }
};