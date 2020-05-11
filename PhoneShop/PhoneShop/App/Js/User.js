$(function() {
	init();
});

function init() {
	$('#okname').hide();
	$('#cancelname').hide();
	$('#okaddress').hide();
	$('#canceladdress').hide();
}

function Changeaddress(ele) {
	$(ele).hide();
	$('#okaddress').show();
	$('#canceladdress').show();
}

function Caneladdress() {
	$('#changeaddress').show();
	$('#okaddress').hide();
	$('#canceladdress').hide();
}

function Okaddress() {
	$('#changeaddress').show();
	$('#okaddress').hide();
	$('#canceladdress').hide();
}

function Changename(ele) {
	$(ele).hide();
	$('#okname').show();
	$('#cancelname').show();
}

function Canelname() {
	$('#changename').show();
	$('#okname').hide();
	$('#cancelname').hide();
}

function Okname() {
	$('#changename').show();
	$('#okname').hide();
	$('#cancelname').hide();
}
