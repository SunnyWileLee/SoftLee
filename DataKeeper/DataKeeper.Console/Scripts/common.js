function post(url, data, success, error) {
    var host = 'http://localhost:60747/';
    $.ajax({
        url: host + url,
        type: "POST",
        contentType: "application/json",
        data: data,
        headers: {
            token: '8FF40BAF-CF97-445B-BD40-D00466E63C03'
        },
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
    var host = 'http://localhost:60747/';
    $.ajax({
        url: host + url,
        type: "GET",
        headers: {
            token:'8FF40BAF-CF97-445B-BD40-D00466E63C03'
        },
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