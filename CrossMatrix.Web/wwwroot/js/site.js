﻿function changeOption(counter) {
	let twoCroses = '001000\n001000\n111110\n001000\n001000\n001000\n';
	let threeCroses = '00010000\n00010000\n00010000\n11111111\n00010000\n00010010\n00010111\n00010010\n';
	let fourCroses = '010010\n111111\n010010\n010010\n111111\n010010';
	let sixCroses = '0000001000000\n0000001000000\n0000001000000\n0000001000000\n0000001000000\n0000001000000\n1111111111111\n0000001000000\n0000001000000\n0000001000000\n0000001000000\n0000001000000\n0000001000000\n';
	let onePlus = '010\n111\n010';
	let arr = [twoCroses, threeCroses, fourCroses, sixCroses, onePlus];

	$("#MatrixString").val(arr[counter]);
	$("#target").click();
}