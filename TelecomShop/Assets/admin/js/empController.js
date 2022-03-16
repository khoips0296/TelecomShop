var emp = {
    init: function () {
        emp.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/Employee/ChangeStatus",
                data: { id: id },
                dataType: "Json",
                type: "POST",
                success: function (response) {
                    if (response.status == true) {
                        btn.text("Active");
                    } else {
                        btn.text("Locked");
                    }
                }
            })
        })
    }
}

emp.init();