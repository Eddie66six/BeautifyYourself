import 'package:flutter/material.dart';

class RoundedButtonComponent extends StatefulWidget {
  RoundedButtonComponent(this.color, this.text, this.textStyle, this.onTap);
  final Color color;
  final String text;
  final TextStyle textStyle;
  final Function onTap;
  @override
  _RoundedButtonComponentState createState() => _RoundedButtonComponentState();
}

class _RoundedButtonComponentState extends State<RoundedButtonComponent> with TickerProviderStateMixin {
  AnimationController colorAnimationController;
  Animation<double> colorAnimation;
  double alpha = 255.0;

  @override
  void initState() {
    super.initState();
    colorAnimationController = AnimationController(vsync: this, duration: Duration(milliseconds: 300));
    colorAnimation = Tween<double>(begin: alpha, end: 200.0).animate(colorAnimationController);
    colorAnimationController.addListener((){
      if(colorAnimationController.status == AnimationStatus.completed){
        setState(() {
          alpha =200;
        });
        colorAnimationController.reset();
      }
      setState(() {
        alpha = colorAnimation.value;
      });
    });
  }

  @override
  void dispose() {
    super.dispose();
    colorAnimationController.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return InkWell(
      onTap: (){
        if(colorAnimationController.status != AnimationStatus.completed)
          colorAnimationController.forward();
        if(widget.onTap != null)
          widget.onTap();
      },
      child: Container(
        padding: EdgeInsets.symmetric(vertical: 5, horizontal: 10),
        decoration: BoxDecoration(
          color: widget.color.withAlpha(alpha.toInt())
        ),
        child: Center(child: Text(widget.text, style: widget.textStyle)),
      ),
    );
  }
}