$(function() {
	init();
});

$(function() { //Events
	$('#opwd').blur(function() {
		opwdLock = false;
		$('#opwd_alert').hide();
		var opwd = $('#opwd').val();
		if (opwd == '')
			$('#opwd_alert').text('请输入原密码').show();
		else if (!RegPwd(opwd))
			$('#opwd_alert').text('密码格式错误').show();
		else
			opwdLock = true;
	});

	$('#npwd').blur(function() {
		npwdLock = false;
		$('#npwd_alert').hide();
		var npwd = $('#npwd').val();
		if (npwd == '')
			$('#npwd_alert').text('请输入新密码').show();
		else if (!RegPwd(npwd))
			$('#npwd_alert').text('密码格式错误').show();
		else
			npwdLock = true;
	});


	$('#cpwd').blur(function() {
		cpwdLock = false;
		$('#cpwd_alert').hide();
		var cpwd = $('#cpwd').val();
		if (cpwd == '')
			$('#cpwd_alert').text('请输入确认密码').show();
		else if (!RegPwd(cpwd))
			$('#cpwd_alert').text('密码格式错误').show();
		else if ($('#npwd').val() != $('#cpwd').val())
			$('#cpwd_alert').text('两次密码不一致').show();
		else
			cpwdLock = true;
	});

})

function init() {
	$('#opwd_alert').hide();
	$('#npwd_alert').hide();
	$('#cpwd_alert').hide();
	$('[data-toggle="tooltip"]').tooltip();
}
var opwdLock = false;
var npwdLock = false;
var cpwdLock = false;


function ChangePwd() {
	if (opwdLock && npwdLock && cpwdLock)
		console.log('change!')
}
