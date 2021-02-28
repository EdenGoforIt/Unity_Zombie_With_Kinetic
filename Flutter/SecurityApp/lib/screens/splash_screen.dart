import 'dart:async';
import 'package:embedded_mobile/login/login_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter/semantics.dart';
import 'package:embedded_mobile/screens/home.dart';
import 'package:embedded_mobile/routes.dart';
import 'package:embedded_mobile/login/login_screen.dart';
import 'package:embedded_mobile/login/login2.dart';

class SplashScreen extends StatefulWidget {
  @override
  _SplashScreen createState() => new _SplashScreen();
}

class _SplashScreen extends State<SplashScreen> {
  @override
  void initState() {
    super.initState();
    new Future.delayed(
        const Duration(seconds: 3),
        () => Navigator.push(
              context,
              MaterialPageRoute(builder: (context) => LoginWithRestfulApi2()),
            ));
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      resizeToAvoidBottomPadding: false,
      body: Stack(
        fit: StackFit.expand,
        children: <Widget>[
          Container(
            decoration: BoxDecoration(color: Colors.amber),
          ),
          Column(
            mainAxisAlignment: MainAxisAlignment.start,
            children: <Widget>[
              Expanded(
                flex: 2,
                child: Container(
                  child: Column(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: <Widget>[
                      Padding(padding: EdgeInsets.only(top: 70)),
                      CircleAvatar(
                        backgroundColor: Colors.white,
                        radius: 100.0,
                        child: Icon(
                          Icons.security,
                          color: Colors.lightGreen,
                          size: 100.0,
                        ),
                      ),
                      Padding(padding: EdgeInsets.only(top: 30)),
                      Text(
                        "First Security",
                        style: TextStyle(
                            color: Colors.green,
                            fontSize: 24,
                            fontWeight: FontWeight.bold),
                      ),
                      Padding(
                        padding: EdgeInsets.only(bottom: 20),
                      ),
                      CircularProgressIndicator(),
                    ],
                  ),
                ),
              ),
              Expanded(
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: <Widget>[
                    Padding(padding: EdgeInsets.only(top: 20)),
                    Text("Secure with Blackboard",
                        style: TextStyle(
                            color: Colors.black,
                            fontSize: 28,
                            fontWeight: FontWeight.w900)),
                    SizedBox(
                      height: 100,
                    ),
                    Text("Copy right@ reserved 2019 Eden Park",
                        style: TextStyle(
                            color: Colors.black,
                            fontSize: 15,
                            fontWeight: FontWeight.w300)),
                  ],
                ),
              ),
            ],
          ),
        ],
      ),
    );
  }
}
