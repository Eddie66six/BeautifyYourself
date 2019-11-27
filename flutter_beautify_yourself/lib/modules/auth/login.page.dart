import 'package:flutter/material.dart';
import 'package:flutter_beautify_yourself/components/rounded-button.component.dart';

class LoginPage extends StatefulWidget {
  @override
  _LoginPageState createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> with TickerProviderStateMixin {
  //logo
  AnimationController logoAnimationController;
  Animation<double> logoMarginTopAnimation;
  double logoMarginTop = 0.0;
  //form
  AnimationController formAnimationController;
  Animation<double> formOpacityAnimation;
  double formOpacity = 0.0;

  //altura do arquivo do logo
  double logoHeight = 200.0;

  //style
  var inputTextStyle = TextStyle(

  );

  @override
  void initState() {
    super.initState();
    Future.delayed(Duration.zero, (){
      var mediaQueryData = MediaQuery.of(context);
      _initLogoAnimation(mediaQueryData);
      _initFormAnimation();
    });
  }

  @override
  void dispose() {
    super.dispose();
    logoAnimationController.dispose();
    formAnimationController.dispose();
  }

  _initLogoAnimation(MediaQueryData mediaQueryData){
    logoAnimationController = AnimationController(vsync: this, duration: Duration(milliseconds: 1500));
    logoMarginTopAnimation = Tween<double>(begin: mediaQueryData.size.height/2 - logoHeight/2, end: mediaQueryData.padding.top).animate(logoAnimationController);
    logoAnimationController.addListener((){
      setState(() {
        logoMarginTop = logoMarginTopAnimation.value;
        if(logoAnimationController.status == AnimationStatus.completed){
          logoMarginTop = mediaQueryData.padding.top;
          formAnimationController.forward();
        }
      });
    });
    logoAnimationController.forward();
  }

  _initFormAnimation(){
    formAnimationController = AnimationController(vsync: this, duration: Duration(seconds: 1));
    formOpacityAnimation = Tween<double>(begin: 0, end: 1).animate(formAnimationController);
    formAnimationController.addListener((){
      setState(() {
        formOpacity = formOpacityAnimation.value;
        if(formAnimationController.status == AnimationStatus.completed){
          formOpacity = 1;
        }
      });
    });
  }

  _buildForm(){
    if(formOpacity == 0){
      return Text("");
    }
    return Center(
      child: Container(
        padding: EdgeInsets.symmetric(horizontal: 20),
        child: Opacity(
          opacity: formOpacity,
          child: Column(
            children: <Widget>[
              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                crossAxisAlignment: CrossAxisAlignment.end,
                children: <Widget>[
                  Text("Beautify", style: TextStyle(color: Colors.white, fontSize: 21)),
                  Text(" "),
                  Text("Yourself",
                    style: TextStyle(color: Color.fromARGB(255, 255,101,66),
                      fontSize: 28, fontWeight: FontWeight.bold))
                ],
              ),
              TextField(
                keyboardType: TextInputType.emailAddress,
                style: TextStyle(color: Colors.white),
                decoration: InputDecoration(
                  hintText: "E-Mail",
                  hintStyle: TextStyle(color: Colors.white)
                ),
              ),
              TextField(
                keyboardType: TextInputType.visiblePassword,
                style: TextStyle(color: Colors.white),
                decoration:InputDecoration(
                  hintText: "Senha",
                  hintStyle: TextStyle(color: Colors.white)
                )
              ),
              Container(
                margin: EdgeInsets.symmetric(vertical: 10),
                child: RoundedButtonComponent(
                  Color.fromARGB(255, 255,101,66),
                  "Entrar",
                  TextStyle(fontSize: 21, color: Colors.white),
                  (){}
                ),
              ),
              Container(
                margin: EdgeInsets.symmetric(vertical: 10),
                child: Text("Esqueci a senha"),
              ),
              Container(
                child: Text("Não tenho cadastro"),
              )
            ],
          ),
        ),
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    var keybordOpend = MediaQuery.of(context).viewInsets.bottom > 0
      && MediaQuery.of(context).size.height < 600 ? 1.5 : 1;
    return Scaffold(
      backgroundColor: Color.fromARGB(255, 136,73,143),
      body: SingleChildScrollView(
        child: Container(
          alignment: Alignment.bottomCenter,
          margin: EdgeInsets.only(top: logoMarginTop),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.center,
            children: <Widget>[
              //logo
              Container(
                height: logoHeight/keybordOpend,
                width: logoHeight/keybordOpend,
                child: Image.asset("assets/logo.png"),
              ),
              //form
              _buildForm()
            ],
          ),
        ),
      ),
    );
  }
}