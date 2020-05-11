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

	$('#fuid').blur(function() {
		fuidLock = false;
		$('#fuid_alert').hide();
		var fuid = $('#fuid').val();
		if (fuid == '')
			$('#fuid_alert').text('请输入手机号').show();
		else if (!RegPhone(fuid))
			$('#fuid_alert').text('手机号码格式错误').show();
		else
			fuidLock = true;
	});

	$('#fpwd').blur(function() {
		fpwdLock = false;
		$('#fpwd_alert').hide();
		var fpwd = $('#fpwd').val();
		if (fpwd == '')
			$('#fpwd_alert').text('请输入密码').show();
		else if (!RegPwd(fpwd))
			$('#fpwd_alert').text('密码格式错误').show();
		else
			fpwdLock = true;
	});

	$('#icode').blur(function() {
		ccodeLock = false;
		$('#cCode_alert').hide();
		var cCode = $('#icode').val();
		if (cCode == '')
			$('#cCode_alert').text('请输入验证码').show();
		else if ($('#cCode').text() != cCode)
			$('#cCode_alert').text('验证码错误').show();
		else
			ccodeLock = true;
	});
})

function init() {
	$('#cCode_alert').hide();
	$('#fpwd_alert').hide();
	$('#fuid_alert').hide();
	$('#uid_alert').hide();
	$('#pwd_alert').hide();
	$('[data-toggle="tooltip"]').tooltip();
}

var uidLock = false;
var pwdLock = false;
var fuidLock = false;
var fpwdLock = false;
var ccodeLock = false;

function Login() {

	if (uidLock && pwdLock)
		console.log('login!')
}

function FindPwd() {

	if (fuidLock && fpwdLock && ccodeLock)
		console.log('Find!')
}

function CreateCCode() {
	var cCode = Math.floor(Math.random() * 10000);
	cCode = cCode < 1000 ? cCode + 1000 : cCode;

	$('#cCode').text(cCode);
}
