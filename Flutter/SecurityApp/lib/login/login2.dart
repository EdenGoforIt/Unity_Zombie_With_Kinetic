import 'dart:io';

import 'package:dio/dio.dart';
import 'package:embedded_mobile/screens/security.dart';
import 'package:flutter/material.dart';
import 'dart:async';
import 'dart:convert';
import 'package:http/http.dart' as http;

class LoginWithRestfulApi2 extends StatefulWidget {
  @override
  _LoginWithRestfulApiState2 createState() => _LoginWithRestfulApiState2();
}

class _LoginWithRestfulApiState2 extends State<LoginWithRestfulApi2> {
  TextEditingController user = new TextEditingController();
  TextEditingController pass = new TextEditingController();
  String username = '';
  bool _isLoggedIn = false;
  static String _baseUrl = "http://blackboardembedded.dx.am/";
  static BaseOptions options = BaseOptions(
      baseUrl: _baseUrl,
      responseType: ResponseType.plain,
      connectTimeout: 30000,
      receiveTimeout: 30000,
      followRedirects: false,
      validateStatus: (code) {
        return code < 500;
      });
  static Dio dio = Dio(options);
  String msg = '';

  Future<dynamic> getJson(Uri uri) async {
    http.Response response = await http.post(uri);
    //llamamos el objetivo json de dart   y decodificar
    return json.decode(response.body);
  }

  Future<List> _login() async {
    Options options = Options(
      contentType: ContentType.parse('application/json'),
    );
    Response response = await dio.post('/login',
        data: {"email": user.text, "password": pass.text}, options: options);
    //check status code and if 302 just redirect to the main page
    print(response);
    if (response.statusCode == 200 || response.statusCode == 302) {
      setState(() => _isLoggedIn = true);
    } else {
      _displaySnackBar(context);
    }
  }

  _displaySnackBar(BuildContext context) {
    return Scaffold.of(context).showSnackBar(
        SnackBar(content: Text("Email or password is incorrect")));
  }

  @override
  Widget build(BuildContext context) {
    return new Scaffold(
      resizeToAvoidBottomPadding: true,
      body: SingleChildScrollView(
        scrollDirection: Axis.vertical,
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            new Stack(
              alignment: Alignment.center,
              children: <Widget>[
                new Container(
                  height: 60.0,
                  width: 60.0,
                  decoration: new BoxDecoration(
                      borderRadius: new BorderRadius.circular(50.0),
                      color: Color(0xFF18D191)),
                  child: new Icon(
                    Icons.security,
                    color: Colors.white,
                  ),
                ),
                new Container(
                  margin: new EdgeInsets.only(right: 50.0, top: 50.0),
                  height: 60.0,
                  width: 60.0,
                  decoration: new BoxDecoration(
                    borderRadius: new BorderRadius.circular(50.0),
                    color: Color(0xFFFC6A7F),
                  ),
                  child: new Icon(
                    Icons.security,
                    color: Colors.white,
                  ),
                ),
                new Container(
                  margin: new EdgeInsets.only(left: 30.0, top: 50.0),
                  height: 60.0,
                  width: 60.0,
                  decoration: new BoxDecoration(
                      borderRadius: new BorderRadius.circular(50.0),
                      color: Color(0xFFFFCE56)),
                  child: new Icon(
                    Icons.security,
                    color: Colors.white,
                  ),
                )
              ],
            ),
            new Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: <Widget>[
                Padding(
                    padding: const EdgeInsets.only(top: 8.0, bottom: 80.0),
                    child: new Text(
                      "First Security",
                      style: new TextStyle(
                          fontSize: 30.0, fontWeight: FontWeight.bold),
                    ))
              ],
            ),
            //TODO: TEXTBOX
            Padding(
              padding: const EdgeInsets.all(18.0),
              child: new TextField(
                controller: user,
                decoration: new InputDecoration(
                    labelText: "Email",
                    fillColor: Colors.red,
                    icon: const Padding(
                        padding: const EdgeInsets.only(top: 15.0),
                        child: const Icon(Icons.person))),
              ),
            ),

            Padding(
              padding: const EdgeInsets.all(18.0),
              child: new TextField(
                key: widget.key,
                autofocus: false,
                obscureText: true,
                maxLength: 8,
                controller: pass,
                decoration: const InputDecoration(
                    labelText: "Password",
                    fillColor: Colors.red,
                    icon: const Padding(
                        padding: const EdgeInsets.only(top: 15.0),
                        child: const Icon(Icons.lock))),
              ),
            ),
            new RaisedButton(
              padding: EdgeInsets.only(top: 0, bottom: 0),
              child: Material(
                borderRadius: BorderRadius.circular(100.0),
                shadowColor: Colors.green,
                elevation: 1000.0,
                child: MaterialButton(
                  minWidth: 200.0,
                  height: 60.0,
                  onPressed: () {
                    _login();
                    if (_isLoggedIn == true) {
                      Navigator.of(context).push(MaterialPageRoute<Null>(
                          builder: (BuildContext context) {
                        return new SecurityScreen();
                      }));
                    }
                  },
                  color: Color(0xFF18D191),
                  child: Text('Login',
                      style: TextStyle(fontSize: 20.0, color: Colors.white)),
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
