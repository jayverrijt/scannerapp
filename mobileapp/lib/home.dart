import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
//import http package manually

class HomePage extends StatefulWidget {
  @override
  State createState() {
    return _SearchBar();
  }
}

class _SearchBar extends State {
  bool? searching, error;
  // ignore: prefer_typing_uninitialized_variables
  var data;
  String? query;
  var dataurl = ("https://php.jverrijt.com/API/ScannerApp/fetchProducts.php");
  var suggestionsurl =
      ("https://php.jverrijt.com/API/ScannerApp/fetchProducts.php?query=");

  // do not use http://localhost/ , Android emulator do not recognize localhost
  // insted use your local ip address or your live URL
  // hit "ipconfig" on Windows or "ip a" on Linux to get IP Address

  @override
  void initState() {
    searching = false;
    error = false;
    query = "";
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
      leading: searching!
          ? IconButton(
              icon: Icon(Icons.arrow_back),
              onPressed: () {
                setState(() {
                  searching = false;
                  //set not searching on back button press
                });
              },
            )
          : Icon(Icons.play_arrow),
      //if searching is true then show arrow back else play arrow
      title: searching! ? searchField() : Text("Producten"),
      actions: [
        IconButton(
            icon: Icon(Icons.search),
            onPressed: () {
              setState(() {
                searching = true;
              });
            }), // search icon button

        //add more icons here
      ],
      backgroundColor: searching!
          ? Color.fromRGBO(59, 66, 82, 1)
          : Color.fromRGBO(59, 66, 82, 1),
      //if searching set background to orange, else set to deep orange
    ));
  }

  Widget searchField() {
    //search input field
    return Container(
        child: TextField(
      autofocus: true,
      style: TextStyle(color: Colors.white, fontSize: 18),
      decoration: InputDecoration(
        hintStyle: TextStyle(color: Colors.white, fontSize: 18),
        hintText: "Zoek voor een product",
        enabledBorder: UnderlineInputBorder(
          borderSide: BorderSide(color: Colors.white, width: 2),
        ), //under line border, set OutlineInputBorder() for all side border
        focusedBorder: UnderlineInputBorder(
          borderSide: BorderSide(color: Colors.white, width: 2),
        ), // focused border color
      ), //decoration for search input field
      onChanged: (value) {
        query = value; //update the value of query
      },
    ));
  }
}

//serarch suggestion data model to serialize JSON data
class SearchSuggestion {
  String id, name;
  SearchSuggestion({required this.id, required this.name});

  factory SearchSuggestion.fromJSON(Map<String, dynamic> json) {
    return SearchSuggestion(
      id: json["id"],
      name: json["name"],
    );
  }
}
