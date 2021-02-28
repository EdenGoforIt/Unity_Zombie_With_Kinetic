import 'package:embedded_mobile/screens/home.dart';
import 'package:flutter/material.dart';
import 'package:embedded_mobile/routes.dart';
import 'package:embedded_mobile/login/login_screen.dart';
import 'package:embedded_mobile/screens/splash_screen.dart';

var routes = <String, WidgetBuilder>{
  "/home": (BuildContext context) => HomeScreen(),
  "/login": (BuildContext context) => LoginWithRestfulApi(),
};

void main() => runApp(new LoginApp());

class LoginApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return new MaterialApp(
      title: 'My Personal Assistant',
      theme: new ThemeData(primarySwatch: Colors.amber),
      home: SplashScreen(),
    );
  }
}
