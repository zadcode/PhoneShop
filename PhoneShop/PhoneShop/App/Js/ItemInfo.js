$(function() {
	Ginit();
	initInfo();
	// LoginCheck();
})

var Pcolor;
var Pconut = 1;
var Pprice;
var Pbrand;
var Pname;
var Ptype;

function initInfo() {
	// var url = decodeURI(window.location.href);
	// var data = url.split('?')[1];
	var data = '133';
	// console.log(data)
	if (data == undefined)
		window.open('HomePage.html', '_self');

	var iid = data.split('=')[1];

	// if (phoneInfo[brand] == undefined)
	// 	window.open('HomePage.html', '_self');

	//	ajax=>testColor,testItem,test
	var brand = testItem[0].sid;
	var name = testItem[0].iname;

	Pbrand = brand;
	Pname = name;

	var color = [];
	for (var i in testColor)
		color.push(testColor[i].cid);
	console.log(color);

	var type = [];
	for (var i in testColor)
		type.push(testType[i].cid);
	console.log(color);

	var colorButton = $('#color')
	var simg = $('#simg') //缩略图
	for (var i in testColor) {
		simg.append(CreateSimg(brand, name, testColor[i].cid));
		colorButton.append(CreateColorButton(testColor[i].cid));
	}
	var path = '../Res/' + brand + '/' + name + '-' + testColor[0].cid + '.jpg' //大图
	$('#image').attr('src', path);
	Pcolor = testColor[0].cid;

	var typeButton = $('#type')
	for (var i in testType) {
		typeButton.append(CreateTypeButton(testType[i].model, testType[i].price))
		console.log('create')
	}
	Ptype = testType[0].model;
	Pprice = testType[0].price;

	document.getElementById('name').innerHTML = Pbrand + ' ' + Pname;
	document.getElementById('price').innerHTML = '¥' + Pprice;
	$('#intro').text(testItem[0].intro)
	
	$('#color').children().eq(1).click();	
	$('#type').children().eq(1).click();	
}

function CreateSimg(brand, name, color) {
	var path = '../Res/' + brand + '/' + name + '-' + color + '.jpg'
	var img = $('<img />').attr('src', path).attr('onclick', 'ChangeImg(this)');
	return img;
}

function CreateColorButton(color) {
	var button = $('<button></button>').attr('id', color).attr('onclick', 'ChangeColor(this)').text(color);
	return button;
}

function CreateTypeButton(type, price) {
	var button = $('<button></button>').attr('id', type+'-'+price).attr('onclick', 'ChangeType(this)').text(type + '	' + price +
		'元');
	return button;
}


function Add() {
	Pconut++;
	document.getElementById('count').value = Pconut;
	UpdateInfo();
}

function Sub() {
	if (Pconut <= 1)
		Pconut = 1;
	else
		Pconut--;
	document.getElementById('count').value = Pconut;
	UpdateInfo();
}

function ChangeColor(ele) {
	document.getElementById(Pcolor).style.borderColor = 'darkgray';
	ele.style.borderColor = 'red';
	Pcolor = ele.id;
	UpdateInfo();
}

function ChangeType(ele) {
	console.log(ele.id)
	console.log(Ptype+'-'+Pprice)
	
	document.getElementById(Ptype+'-'+Pprice).style.borderColor = 'darkgray';
	ele.style.borderColor = 'red';
	Ptype = ele.id.split('-')[0];
	Pprice = ele.id.split('-')[1];
	UpdateInfo();
}

function ChangeImg(ele) {
	var path = $(ele).attr('src');
	$('#image').attr('src', path);
}

function UpdateInfo() {
	document.getElementById('selectInfo').innerHTML = '已选:' + Pbrand + ' ' + Pname + ' ' + Pcolor + ' ' + Ptype + ' ' +
		'×' + Pconut;
	$('#price').text(Pprice+'元');
	document.getElementById('sumPrice').innerHTML = '¥' + (Pconut * Pprice);
}

// function Buy() {
// 	if (sessionStorage['loginId'] == undefined || sessionStorage['loginId'] == null) {
// 		alert('请先登录');
// 		return;
// 	}
// 	console.log(1)

// 	var path = 'Pay.html?' + Pbrand + '-' + Pname + '-' + Pprice + '-' + Pcolor + '-' + Pconut;
// 	window.open(encodeURI(path), '_self');

// }
