package main

import (
	"encoding/json"
	"net/http"
	"time"
)

type Response struct {
	Number int `json:"number"`
}

func randomNumberRequestHandler(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Content-Type", "application/json")

	var response = Response{
		Number: int(time.Now().Second()),
	}

	json.NewEncoder(w).Encode(response)
}

func main() {
	http.HandleFunc("/random-number", randomNumberRequestHandler)
	http.ListenAndServe(":5001", nil)
}
