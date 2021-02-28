class JsonUser {
  String email;

  JsonUser({
    this.email,
  });

  factory JsonUser.fromJson(Map<String, dynamic> parsedJson) {
    Map json = parsedJson['user'];
    return JsonUser(
      email: json['email'],
    );
  }
}
