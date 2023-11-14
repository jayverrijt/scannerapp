import 'package:flutter/material.dart';
import 'package:iosapp/Colors.dart';

void main() => runApp(new HomePage());

class HomePage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return new MaterialApp(
      title: 'ScannerApp',
      theme: new ThemeData(
        primarySwatch: NordMain,
        scaffoldBackgroundColor: Color.fromRGBO(46, 52, 57, 1),
      ),
      home: new MyHomePage(title: 'Voer EAN code in'),
    );
  }
}

class MyHomePage extends StatefulWidget {
  MyHomePage({Key? key, required this.title}) : super(key: key);

  final String title;

  @override
  _MyHomePageState createState() => new _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {
  void _incrementCounter() {
    setState(() {});
  }

  @override
  Widget build(BuildContext context) {
    return new Scaffold(
      appBar: new AppBar(
        title: new Text(widget.title),
      ),
      body: new Center(
        child: new Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            Theme(
              data: new ThemeData(
                primaryColor: Color.fromRGBO(94, 129, 172, 1),
                primaryColorDark: Color.fromRGBO(94, 129, 172, 1),
                hintColor: Color.fromRGBO(94, 129, 172, 1), //placeholder color
              ),
              child: TextFormField(
                decoration: InputDecoration(
                  focusedBorder: new OutlineInputBorder(
                    borderSide: BorderSide(
                      color: Color.fromRGBO(94, 129, 172, 1),
                      style: BorderStyle.solid,
                    ),
                  ),
                  enabledBorder: new OutlineInputBorder(
                    borderSide: BorderSide(
                      color: Color.fromRGBO(94, 129, 172, 1),
                      style: BorderStyle.solid,
                    ),
                  ),
                  errorBorder: new OutlineInputBorder(
                    borderSide: BorderSide(
                      color: Colors.red,
                      width: 1.0,
                      style: BorderStyle.solid,
                    ),
                  ),
                  labelText: 'Voer EAN code in',
                  prefixIcon: const Icon(
                    Icons.production_quantity_limits_rounded,
                    color: Color.fromRGBO(94, 129, 172, 1),
                  ),
                  border: new OutlineInputBorder(
                    borderSide: BorderSide(
                      color: Color.fromRGBO(94, 129, 172, 1),
                      style: BorderStyle.solid,
                    ),
                  ),
                  hintText: 'XXXXXXXXXXXXXX',
                ),
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return 'Voer astublieft een EAN code in';
                  }
                  return null;
                },
              ),
            ),
            SizedBox(
              height: 20.0,
            ),
            OutlinedButton(
              onPressed: null,
              style: ButtonStyle(
                shape: MaterialStateProperty.all(RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(30.0))),
              ),
              child: const Text("Zoeken"),
            )
          ],
        ),
      ),
    );
  }
}
