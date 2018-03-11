function post(url, data, success, error) {
    var host = 'http://localhost:4345/';
    $.ajax({
        url: host + url,
        type: "POST",
        contentType: "application/json",
        data: data,
        success: function (response) {
            if (success == null) {
                return false;
            }
            success(response)
        },
        error: function (response) {
            if (error == null) {
                return false;
            }
            error(response)
        }
    });
}

function get(url, success, error) {
    var host = 'http://localhost:4345/';
    $.ajax({
        url: host + url,
        type: "GET",
        success: function (response) {
            if (success == null) {
                return false;
            }
            success(response)
        },
        error: function (response) {
            if (error == null) {
                return false;
            }
            error(response)
        }
    });
}