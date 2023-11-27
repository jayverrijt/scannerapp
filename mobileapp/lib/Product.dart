import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

class ProductData {
  final String name;
  final String ean;
  final String artcode;
  final String artnmr;
  final String formule;

  ProductData(
      {required this.name,
      required this.ean,
      required this.artcode,
      required this.artnmr,
      required this.formule});

  factory ProductData.fromJson(Map<String, dynamic> json) {
    return ProductData(
        name: json['artikelnaam'].toString(),
        ean: json['ean'].toString(),
        artcode: json['artcode'].toString(),
        artnmr: json['artnummer'].toString(),
        formule: json['formule'].toString());
  }
}

class Product extends StatelessWidget {
  final String search;

  const Product({Key? key, required this.search}) : super(key: key);

  Future<ProductData> sendData() async {
    final response = await http.post(
      Uri.parse('http://jverrijt.com/API/ScannerApp/fetchProducts.php'),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
      },
      body: jsonEncode(<String, String>{
        'ean': search,
      }),
    );

    if (response.statusCode == 201) {
      return ProductData.fromJson(
          jsonDecode(response.body) as Map<String, dynamic>);
    } else {
      throw Exception('Failed to load data');
    }
  }

  @override
  Widget build(BuildContext context) {
    sendData();

    return Scaffold(
      appBar: AppBar(
        title: const Text('Product Information'),
        backgroundColor: const Color.fromRGBO(59, 66, 82, 1),
      ),
      body: (Container(
          child: Center(
        child: buildFutureBuilder(),
      ))),
    );
  }

  @override
  FutureBuilder<ProductData> buildFutureBuilder() {
    return FutureBuilder<ProductData>(
      future: sendData(),
      builder: (context, snapshot) {
        if (snapshot.hasData) {
          return Text(snapshot.data!.name);
        } else if (snapshot.hasError) {
          return Text('${snapshot.error}');
        }
        return const CircularProgressIndicator();
      },
    );
  }
}
