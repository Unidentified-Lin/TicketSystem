function GetValidToken() {
	return document.querySelector("input[type=hidden][name=__RequestVerificationToken]").value;
}

export function fetchResourceGet(url, value, successFunc) {
	const request = new Request(url, {
		method: "GET",
	});
	fetch(request)
		.then((response) => response.json())
		.then((json) => {
			successFunc(json);
			console.log(json);
			console.log(JSON.stringify(json));
		})
		.catch((ex) => {
			console.error(ex);
		});
}
export function fetchResourcePost(url, value, successFunc) {
	let request = new Request(url, {
		method: "POST",
		headers: {
			Accept: "application/json; charset=utf-8",
			"Content-Type": "application/json;charset=UTF-8",
			requestverificationtoken: GetValidToken(),
		},
		body: JSON.stringify(value),
	});
	fetch(request)
		.then((response) => {
			console.log("POST Success");
			return response.json();
		})
		.then((json) => {
			if (successFunc) {
				successFunc(json);
			}
			if (json) {
				if (json.isShowAlert) {
					popAlert(json.alertType, json.heading, json.message, json.duration);
				}
				console.log(json);
				console.log(JSON.stringify(json));
			}
		})
		.catch((ex) => {
			console.log("POST Error");
			console.error(ex);
		});
}
