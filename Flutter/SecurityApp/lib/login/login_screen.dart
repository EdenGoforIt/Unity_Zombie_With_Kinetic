import 'dart:async';
import 'dart:convert';
import 'dart:io';
import 'package:embedded_mobile/screens/home.dart';
import 'package:dio/dio.dart';
import 'package:flutter/material.dart';
import 'package:embedded_mobile/models/user.dart';

var routes = <String, WidgetBuilder>{
  "/home": (BuildContext context) => HomeScreen(),
  "/login": (BuildContext context) => LoginWithRestfulApi(),
};

class LoginWithRestfulApi extends StatefulWidget {
  @override
  _LoginWithRestfulApiState createState() => _LoginWithRestfulApiState();
}

class _LoginWithRestfulApiState extends State<LoginWithRestfulApi>
    with TickerProviderStateMixin {
  static var uri = "http://blackboardembedded.dx.am";

  static BaseOptions options = BaseOptions(
      baseUrl: uri,
      responseType: ResponseType.plain,
      connectTimeout: 30000,
      receiveTimeout: 30000,
      followRedirects: false,
      validateStatus: (code) {
        return code < 500;
      });

  static Dio dio = Dio(options);

  GlobalKey<ScaffoldState> _scaffoldKey = GlobalKey<ScaffoldState>();

  TextEditingController _emailController = TextEditingController();

  TextEditingController _passwordController = TextEditingController();

  bool _isLoading = false;

  Future<bool> _onBackPressed() {}

  Future<dynamic> _loginUser(String email, String password) async {
    try {
      Options options = Options(
        contentType: ContentType.parse('application/json'),
      );

      Response response = await dio.post('/login',
          data: {"email": email, "password": password}, options: options);

      if (response.statusCode == 200 ||
          response.statusCode == 201 )  {
        var responseJson = json.decode(response.data);
        return responseJson;
      } else if (response.statusCode == 401) {
        throw Exception("Incorrect Email/Password");
      } else
        throw Exception('Authentication Error');
    } on DioError catch (exception) {
      if (exception == null ||
          exception.toString().contains('SocketException')) {
        throw Exception("Network Error");
      } else if (exception.type == DioErrorType.RECEIVE_TIMEOUT ||
          exception.type == DioErrorType.CONNECT_TIMEOUT) {
        throw Exception(
            "Could'nt connect, please ensure you have a stable network.");
      } else {
        return null;
      }
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      key: _scaffoldKey,
      appBar: AppBar(
          leading: new IconButton(
            icon: new Icon(Icons.arrow_back, color: Colors.black),
            onPressed: () => Navigator.of(context).pushNamed('/login'),
          ),
          title: Text("Send Location")),
      body: Center(
        child: Container(
          child: _isLoading
              ? CircularProgressIndicator()
              : Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: <Widget>[
                    Padding(
                      padding: const EdgeInsets.all(20.0),
                      child: TextField(
                        controller: _emailController,
                        decoration: InputDecoration(
                          hintText: 'Email',
                        ),
                      ),
                    ),
                    Padding(
                      padding: const EdgeInsets.all(20.0),
                      child: TextField(
                        controller: _passwordController,
                        decoration: InputDecoration(
                          hintText: 'Password',
                        ),
                      ),
                    ),
                    new SizedBox(
                      width: 200,
                      height: 50,
                      child: RaisedButton(
                        shape: new RoundedRectangleBorder(
                            borderRadius: new BorderRadius.circular(50.0)),
                        child: Text("Login"),
                        color: Colors.amber,
                        onPressed: () async {
                          setState(() => _isLoading = true);
                          var res = await _loginUser(
                              _emailController.text, _passwordController.text);
                          setState(() => _isLoading = false);

                          JsonUser user = JsonUser.fromJson(res);
                          if (user != null) {
                            Navigator.of(context).push(MaterialPageRoute<Null>(
                                builder: (BuildContext context) {
                              return new LoginScreen(
                                user: user,
                              );
                            }));
                          } else {
                            Scaffold.of(context).showSnackBar(SnackBar(
                                content:
                                    Text("Email or password is incorrect")));
                          }
                        },
                      ),
                    ),
                  ],
                ),
        ),
      ),
    );
  }
}

class LoginScreen extends StatelessWidget {
  LoginScreen({@required this.user});

  final JsonUser user;
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text("Login Screen")),
      body: Center(
        child: user != null
            ? Text("Logged IN \n \n Email: ${user.email} ")
            : Text("Yore not Logged IN"),
      ),
    );
  }
}
