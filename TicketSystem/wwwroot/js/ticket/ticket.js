import { fetchResourceGet, fetchResourcePost } from "../common.js";

var vueTickets;
function genCards(json) {
	vueTickets = new Vue({
		el: "#tickets",
		data: {
			tickets: json,
		},
		methods: {
			resolved: function (guid) {
				console.log(`Resolve guid: ${guid}`);
				fetchResourcePost("../Ticket/Resolve", guid, function (json) {
					console.log(json);
				});
			},
		},
	});
}

function testJson(json) {
	console.log(json);
}

window.onload = function () {
	console.log("window onload");
	fetchResourceGet("../Ticket/GetTickets", null, genCards);
	// fetchResourceGet("../Ticket/GetTickets", null, testJson);

	var addBtn = document.getElementById("add-ticket");
	addBtn.addEventListener("click", function () {
		let postData = {};
		// postData.summary = this.$data.input.summary;
		// postData.description = this.$data.input.description;
		postData.summary = "Demo summary";
		postData.description = "Demo description";
		fetchResourcePost("../Ticket/NewTicket", postData, function (json) {
			console.log("response");
			console.log(json);
		});
	});
};
