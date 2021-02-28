import 'package:flutter/material.dart';

class HomeScreen extends StatefulWidget {
  @override
  _HomeScreenState createState() => new _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen> with TickerProviderStateMixin {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Can you hear Blackboard?"),
        actions: <Widget>[
          Padding(
            child: Icon(Icons.search),
            padding: const EdgeInsets.only(right: 10.0),
          )
        ],
      ),
      floatingActionButton: FloatingActionButton(
        backgroundColor: Colors.white,
        onPressed: () => {},
        child: Icon(Icons.send, color: Colors.white),
      ),
    );
  }
}
