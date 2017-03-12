@model ConsoleApplication.Models.ViewModels.TicksViewModel
@{
	var aaa = "abcdefg";
}
<html ng-app='app'>
<head>
	<link href="/css/bootstrap.min.css" rel="stylesheet"/>
	<script src="/js/jquery.min.js"></script>
	<script src="/js/angular1.5.8.min.js"></script>
	<script src="/js/bootstrap.min.js"></script>
</head>
<body ng-controller='demo'>
	<div class='container'>
		<div class='row'>
			<div class='col-md-4'>
				<label>Message:</label>
				@ViewBag.Message
			</div>
			<div class='col-md-4'>
				<label>Time:</label>
				@ViewBag.Time
			</div>
			<div class='col-md-4'>
				@aaa
			</div>
		</div>
		
		<div class='row'>
			<div class='col-md-4'>
				{{a}}
			</div>
		</div>
		
		<form action='home/index' method='post'>
			@Html.TextBoxFor(model => model.id) <br>
			@Html.TextBoxFor(model => model.tick) <br>
			<button type='submit' class='btn'>Submit - Form</button>
		</form>
		<br>
		<div>
			<input type='text' ng-model='txt.id' /><br>
			<input type='text' ng-model='txt.tick'/><br>
			<button class='btn' ng-click='doAjax()'>Submit - Ajax</button>
			<div>
				{{ajax.id}} &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				{{ajax.tick}} &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				{{ajax.tt}} &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			</div>
		</div>
		
	</div>
</body>
<script>
	var app = angular.module("app",[]);
	app.controller("demo",demo);
	function demo($scope,$http){
		$scope.a = "Angular test";
		
		$scope.ajax = {
			id:"",
			tick:"",
			tt:"",
		}
		
		$scope.doAjax = function(){
			$http({
				method:'POST',
				url:'/home/doAjax',
				data:$.param({id:$scope.txt.id,tick:$scope.txt.tick,tt:"tt"}),	//to serial data or must using file_get_contents to get post data
				headers: {'Content-Type': 'application/x-www-form-urlencoded'}
			}).then(function success(msg){
				console.log(msg.data);
				$scope.ajax = msg.data;
			},function error(err,status,headers,config){
				console.log(err);
			});
		}
		
		
	}
</script>
</html>