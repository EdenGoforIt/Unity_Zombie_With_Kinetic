import 'dart:async';
import 'dart:convert';
import 'dart:io';
import 'package:http/http.dart' as http;
import 'package:flutter/material.dart';

class SecurityScreen extends StatefulWidget {
  @override
  _SecurityScreen createState() => new _SecurityScreen();
}

class _SecurityScreen extends State<SecurityScreen> {
  static bool _selectOn = false;

  void setButtonColor() async {
    _selectOn = await _getState();

    print(_selectOn.toString());
  }

  @override
  void initState() {
    super.initState();
    setButtonColor();
  }

  static const baseURL = "http://blackboardembedded.dx.am/";

  Future<bool> _getState() async {
    String url = "http://blackboardembedded.dx.am/security";
    HttpClient httpClient = new HttpClient();
    HttpClientRequest request = await httpClient.getUrl(Uri.parse(url));
    request.headers.set('content-type', 'application/json');

    HttpClientResponse response = await request.close();

    // HttpClientResponse response = await request.close();
    // todo - you should check the response.statusCode
    //String reply = await response.transform(utf8.decoder).join();
    await for (var contents in response.transform(Utf8Decoder())) {
      var data = jsonDecode(contents);
      var st = data['state'];
      if (st == 1) {
        return true;
      } else {
        return false;
      }
    }

    // state = reply['state'];
    // httpClient.close();

    // print(reply);
  }

  _setTrue() async {
    String url = "http://blackboardembedded.dx.am/securities/settrue";
    HttpClient httpClient = new HttpClient();
    HttpClientRequest request = await httpClient.getUrl(Uri.parse(url));
    request.headers.set('content-type', 'application/json');

    HttpClientResponse response = await request.close();
    // todo - you should check the response.statusCode
    String reply = await response.transform(utf8.decoder).join();
    httpClient.close();
    print(reply);
  }

  _setFalse() async {
    String url = "http://blackboardembedded.dx.am/securities/setfalse";
    HttpClient httpClient = new HttpClient();
    HttpClientRequest request = await httpClient.getUrl(Uri.parse(url));
    request.headers.set('content-type', 'application/json');

    HttpClientResponse response = await request.close();
    // todo - you should check the response.statusCode
    String reply = await response.transform(utf8.decoder).join();
    httpClient.close();
    print(reply);
  }

  dispose() {
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text("First Security")),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            RaisedButton(
              padding: const EdgeInsets.only(
                  left: 80, right: 80, top: 50, bottom: 50),
              color: _selectOn ? Colors.red : Colors.green,
              onPressed: () async {
                setState(() => _selectOn = !_selectOn);
                _setTrue();
              },
              child: Text("ON"),
            ),
            SizedBox(
              height: 20,
            ),
            RaisedButton(
              padding: const EdgeInsets.only(
                  left: 80, right: 80, top: 50, bottom: 50),
              color: _selectOn ? Colors.green : Colors.red,
              onPressed: () async {
                setState(() => _selectOn = !_selectOn);
                _setFalse();
              },
              child: Text("OFF"),
            ),
          ],
        ),
      ),
      bottomNavigationBar: BottomNavigationBar(
        currentIndex: 0, // this will be set when a new tab is tapped
        items: [
          BottomNavigationBarItem(
            icon: new Icon(Icons.home),
            title: new Text('Home'),
          ),
          BottomNavigationBarItem(
            icon: new Icon(Icons.security),
            title: new Text('Security'),
          ),
          BottomNavigationBarItem(icon: Icon(Icons.watch), title: Text('Alarm'))
        ],
      ),
    );
  }
}
