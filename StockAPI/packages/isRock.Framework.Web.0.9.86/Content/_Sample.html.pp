﻿<!DOCTYPE html>
<html>
<head>
	<meta charset="utf-8" />
    <title>Sample</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Content/toastr.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/toastr.min.js"></script>
    <script src="Scripts/vue.min.js"></script>
    <script src="Scripts/isRockFx.js"></script>
    <script>
        function Button1_click() {
            //呼叫API
            ExecuteAPI('Example', 'TestMethodA', { 'ValueA': 100, 'ValueB': 'abc' },
               function (ret) {
                   //如果正確顯示結果
                   alert('result : ' + ret.Data.value1 + ret.Data.value2);
               });
        }

        //hook events
        $(document).ready(function () {
            $('#Button1').click(Button1_click);
        });
    </script>
</head>
<body>
    <div class="row" style="margin: 12px">
        <div class="col-lg-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    範例 :
                </div>
                <div class="panel-body">
                    <button class="btn btn-primary" id="Button1" type="button">GetData</button>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
