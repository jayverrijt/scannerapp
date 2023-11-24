import 'package:flutter/material.dart';

class Product extends StatelessWidget {
  final String search;
  Product({Key? key, required this.search}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: Text('Product Information'),
          backgroundColor: Color.fromRGBO(59, 66, 82, 1),
        ),
        body: Center(
          child: Text(search),
        ));
  }
}
