
$.validator.methods.number = function (value, element) {
	return this.optional(element) || /^\d+([.,]\d\d)?$/.test(value);
}