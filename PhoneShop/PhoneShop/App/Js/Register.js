$(function() {
	init();
});

$(function() { //Events
	$('#uid').blur(function() {
		uidLock = false;
		$('#uid_alert').hide();
		var uid = $('#uid').val();
		if (uid == '')
			$('#uid_alert').text('请输入手机号').show();
		else if (!RegPhone(uid))
			$('#uid_alert').text('手机号码格式错误').show();
		else
			uidLock = true;
	});

	$('#pwd').blur(function() {
		pwdLock = false;
		$('#pwd_alert').hide();
		var pwd = $('#pwd').val();
		if (pwd == '')
			$('#pwd_alert').text('请输入密码').show();
		else if (!RegPwd(pwd))
			$('#pwd_alert').text('密码格式错误').show();
		else
			pwdLock = true;
	});


	$('#pwd2').blur(function() {
		pwd2Lock = false;
		$('#pwd2_alert').hide();
		var pwd2 = $('#pwd2').val();
		if (pwd2 == '')
			$('#pwd2_alert').text('请输入密码').show();
		else if (!RegPwd(pwd2))
			$('#pwd2_alert').text('密码格式错误').show();
		else if ($('#pwd').val() != $('#pwd2').val())
			$('#pwd2_alert').text('两次密码不一致').show();
		else
			pwd2Lock = true;
	});



})

var uidLock = false;
var pwdLock = false;
var pwd2Lock = false;




function init() {
	$('#uid_alert').hide();
	$('#pwd_alert').hide();
	$('#pwd2_alert').hide();
	$('[data-toggle="tooltip"]').tooltip();
}

function Register() {
	if (uidLock && pwdLock && pwd2Lock)
		console.log('Register!');
}
