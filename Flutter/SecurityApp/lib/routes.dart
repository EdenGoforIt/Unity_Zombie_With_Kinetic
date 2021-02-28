import 'package:flutter/material.dart';

class MyNavigator {
  static void goToHome(BuildContext context) {
    Navigator.pushNamed(context, "/home");
  }

  static void goToLogin(BuildContext context) {
    Navigator.pushNamed(context, "/login");
  }
}
