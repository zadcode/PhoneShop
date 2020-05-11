$(function() {
	init();

	$('[name="selectAll"]').change(function() {
		// console.log($(this.parentElement.parentElement).next().children().children('input:first-child'));		
		$(this.parentElement.parentElement).next().children().children('input:first-child').prop('checked',$(this).prop('checked'));
	});
});

function init() {

}
