# TicketSystem

## Task 1

> Please write down all the use cases either in text or diagram you can think for Phase I and Phase II requirement separately.

Please see pdf document: `TicketSystem Task1 Flow.pdf` and `TicketSystem Task1 Swimlane.pdf`.

## Task 2

> Please implement the A. Phase I Requirement by .NET Core MVC/Java Spring MVC/PHP Laravel 8/ Python Django. For front-end, you can use any framework you like, but we prefer Vue XDD.

This project.

Use sqlite database(`app.db`).

Testing accounts and passwords:

- QA: qa@gmail.com `ticketsystem`
- RD: rd@gmail.com `ticketsystem`
- Administrator: admin@gmail.com `ticketsystem`

## Task 3

> Think of yourself as an architect. How will you design this system, please write down the design document at least to include data model, class diagram and UI mock up.

Please see pdf document: `TicketSystem Task3 Schema.pdf`

### class diagram

![](https://i.imgur.com/W6eiz8q.png)

![](https://i.imgur.com/U9204QC.png)

## Task 4

> If we are going to open the system for 3rd party to use, can you please design the Web API(Json format) and api document?

### Endpoints

- `GET` `/api/2021-09/ticket.json`
  [_Retrieves a list of tickets_](#retrieves-a-list-of-tickets)
- `GET` `/api/2021-09/ticket/{ticket_id}.json`
  [_Retrieves a single ticket by ID_](#retrieves-a-single-ticket-by-id)
- `PUP` `/api/2021-09/ticket/{ticket_id}.json`
  [_Update an existing ticket_](#update-an-existing-ticket)

#### The ticket object

```json
{
	"id": "F3948628-EC64-4806-850C-4027F2B07AC5",
	"type": "bug",
	"summary": "Example",
	"description": "Description content with message.",
	"priority": 1,
	"severity": 2,
	"resolved": false,
	"created_at": "2012-08-24T14:01:47-04:00",
	"resolved_at": "2012-08-24T14:01:47-04:00",
	"creater_id": "F3948628-EC64-4806-850C-4027F2B07AC5",
	"resolver_id": "F3948628-EC64-4806-850C-4027F2B07AC5"
}
```

#### Properties

| Properties    | Description                                                                       |
| ------------- | --------------------------------------------------------------------------------- |
| `id`          | The ID of the ticket.                                                             |
| `type`        | The ticket type of the ticket.                                                    |
| `summary`     | The summary of the ticket.                                                        |
| `description` | The description of the ticket.                                                    |
| `priority`    | The priority of the ticket. The small number has more priority. Which from 1-5.   |
| `severity`    | The severity of the ticket. The small number has more severity. Which from 1-5.   |
| `resolved`    | Whether the ticket is resolved. If true, then the ticket is resolved by resolver. |
| `created_at`  | The date and time when the ticket was created.                                    |
| `resolved_at` | The date and time when the ticket was resolved. ticket.                           |
| `creater_id`  | The user ID who created the ticket.                                               |
| `resolver_id` | The user ID who resolved the ticket.                                              |

#### Retrieves a list of tickets

Retrieves a list of tickets. Some description here.

Parameters
`api_version` : required
`limit` : _<= 250, default: 50_

Response

```json
HTTP/1.1 200 OK
{
	"tickets": [
		{
			"id": "F3948628-EC64-4806-850C-4027F2B07AC5",
			"type": "bug",
			"summary": "Example",
			"description": "Description content with message.",
			"priority": 1,
			"severity": 2,
			"resolved": false,
			"created_at": "2012-08-24T14:01:47-04:00",
			"resolved_at": "2012-08-24T14:01:47-04:00",
			"creater_id": "F3948628-EC64-4806-850C-4027F2B07AC5",
			"resolver_id": "F3948628-EC64-4806-850C-4027F2B07AC5"
		}
	]
}
```

#### Retrieves a single ticket by ID

Retrieves a single ticket by ID. Some description here.

Parameters
`api_version` : required
`ticket_id` : required

Response

```json
HTTP/1.1 200 OK
{
	"ticket": {
		"id": "F3948628-EC64-4806-850C-4027F2B07AC5",
		"type": "bug",
		"summary": "Example",
		"description": "Description content with message.",
		"priority": 1,
		"severity": 2,
		"resolved": false,
		"created_at": "2012-08-24T14:01:47-04:00",
		"resolved_at": "2012-08-24T14:01:47-04:00",
		"creater_id": "F3948628-EC64-4806-850C-4027F2B07AC5",
		"resolver_id": "F3948628-EC64-4806-850C-4027F2B07AC5"
	}
}
```

#### Update an existing ticket

Update an existing ticket. Some description here.

Parameters
`api_version` : required
`ticket_id` : required

Response

```json
HTTP/1.1 200 OK
{
	"ticket": {
		"id": "F3948628-EC64-4806-850C-4027F2B07AC5",
		"type": "bug",
		"summary": "Example",
		"description": "Description content with message.",
		"priority": 1,
		"severity": 2,
		"resolved": false,
		"created_at": "2012-08-24T14:01:47-04:00",
		"resolved_at": "2012-08-24T14:01:47-04:00",
		"creater_id": "F3948628-EC64-4806-850C-4027F2B07AC5",
		"resolver_id": "F3948628-EC64-4806-850C-4027F2B07AC5"
	}
}
```
