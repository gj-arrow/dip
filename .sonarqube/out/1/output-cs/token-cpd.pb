´J
GD:\Student\sonar\diplom-master\SikuliSharp\AsyncTwoWayStreamsHandler.cs
	namespace		 	
SikuliSharp		
 
{

 
public 
	interface -
!IAsyncDuplexStreamsHandlerFactory 3
{ &
IAsyncTwoWayStreamsHandler 
Create #
(# $

TextReader$ .
stdout/ 5
,5 6

TextReader7 A
stderrB H
,H I

TextWriterJ T
stdinU Z
)Z [
;[ \
} 
public 
class ,
 AsyncDuplexStreamsHandlerFactory .
:/ 0-
!IAsyncDuplexStreamsHandlerFactory1 R
{ 
public &
IAsyncTwoWayStreamsHandler	 #
Create$ *
(* +

TextReader+ 5
stdout6 <
,< =

TextReader> H
stderrI O
,O P

TextWriterQ [
stdin\ a
)a b
{ 
return 	
new
 %
AsyncTwoWayStreamsHandler '
(' (
stdout( .
,. /
stderr0 6
,6 7
stdin8 =
)= >
;> ?
} 
} 
public 
	interface &
IAsyncTwoWayStreamsHandler ,
:- .
IDisposable/ :
{ 
string 
	ReadUntil	 
( 
double 
timeoutInSeconds *
,* +
params, 2
string3 9
[9 :
]: ;
expectedStrings< K
)K L
;L M
IEnumerable 
< 
string 
> 
ReadUpToNow !
(! "
double" (
timeoutInSeconds) 9
)9 :
;: ;
void 
	WriteLine 
( 
string 
command 
)  
;  !
void 
WaitForExit 
( 
) 
; 
} 
public   
class   %
AsyncTwoWayStreamsHandler   '
:  ( )&
IAsyncTwoWayStreamsHandler  * D
{!! 
private"" 	
readonly""
 

TextReader"" 
_stdout"" %
;""% &
private## 	
readonly##
 

TextReader## 
_stderr## %
;##% &
private$$ 	
readonly$$
 

TextWriter$$ 
_stdin$$ $
;$$$ %
private%% 	
readonly%%
 
Task%% 
_readStderrTask%% '
;%%' (
private&& 	
readonly&&
 
Task&& 
_readStdoutTask&& '
;&&' (
private'' 	
readonly''
 
BlockingCollection'' %
<''% &
string''& ,
>'', -
_pendingOutputLines''. A
=''B C
new''D G
BlockingCollection''H Z
<''Z [
string''[ a
>''a b
(''b c
)''c d
;''d e
public)) %
AsyncTwoWayStreamsHandler))	 "
())" #

TextReader))# -
stdout)). 4
,))4 5

TextReader))6 @
stderr))A G
,))G H

TextWriter))I S
stdin))T Y
)))Y Z
{** 
_stdout++ 

=++ 
stdout++ 
;++ 
_stderr,, 

=,, 
stderr,, 
;,, 
_stdin-- 	
=--
 
stdin-- 
;-- 
_readStdoutTask// 
=// 
new// 
Task// 
(// 
ReadStdoutAsync// -
)//- .
;//. /
_readStdoutTask00 
.00 
Start00 
(00 
)00 
;00 
_readStderrTask22 
=22 
new22 
Task22 
(22 
ReadStderrAsync22 -
)22- .
;22. /
_readStderrTask33 
.33 
Start33 
(33 
)33 
;33 
}44 
public66 
string66	 
	ReadUntil66 
(66 
double66  
timeoutInSeconds66! 1
,661 2
params663 9
string66: @
[66@ A
]66A B
expectedStrings66C R
)66R S
{77 
while88 
(88	 

true88
 
)88 
{99 
string:: 

line:: 
;:: 
if;; 
(;; 
timeoutInSeconds;; 
>;; 
$num;; 
);; 
{<< 
var== 
timeout==	 
=== 
TimeSpan== 
.== 
FromSeconds== '
(==' (
timeoutInSeconds==( 8
)==8 9
;==9 :
if>> 
(>> 	
!>>	 

_pendingOutputLines>>
 
.>> 
TryTake>> %
(>>% &
out>>& )
line>>* .
,>>. /
timeout>>0 7
)>>7 8
)>>8 9
throw?? 
new?? 
TimeoutException??  
(??  !
string??! '
.??' (
Format??( .
(??. /
$str??/ Z
,??Z [
timeout??\ c
)??c d
)??d e
;??e f
}@@ 
elseAA 
{BB 
lineCC 	
=CC
 
_pendingOutputLinesCC 
.CC  
TakeCC  $
(CC$ %
)CC% &
;CC& '
}DD 
ifFF 
(FF 
expectedStringsFF 
.FF 
AnyFF 
(FF 
sFF 
=>FF  
lineFF! %
.FF% &
IndexOfFF& -
(FF- .
sFF. /
,FF/ 0
StringComparisonFF1 A
.FFA B
OrdinalFFB I
)FFI J
>FFK L
-FFM N
$numFFN O
)FFO P
)FFP Q
{GG 
returnHH 
lineHH 
;HH 
}II 
}JJ 
}KK 
publicMM 
IEnumerableMM	 
<MM 
stringMM 
>MM 
ReadUpToNowMM (
(MM( )
doubleMM) /
timeoutInSecondsMM0 @
)MM@ A
{NN 
whileOO 
(OO	 

trueOO
 
)OO 
{PP 
stringQQ 

lineQQ 
;QQ 
ifRR 
(RR 
_pendingOutputLinesRR 
.RR 
TryTakeRR #
(RR# $
outRR$ '
lineRR( ,
,RR, -
TimeSpanRR. 6
.RR6 7
FromSecondsRR7 B
(RRB C
timeoutInSecondsRRC S
)RRS T
)RRT U
)RRU V
yieldSS 

returnSS 
lineSS 
;SS 
elseTT 
yieldUU 

breakUU 
;UU 
}VV 
}WW 
publicYY 
voidYY	 
	WriteLineYY 
(YY 
stringYY 
commandYY &
)YY& '
{ZZ 
_stdin[[ 	
.[[	 

	WriteLine[[
 
([[ 
command[[ 
)[[ 
;[[ 
}\\ 
public^^ 
void^^	 
WaitForExit^^ 
(^^ 
)^^ 
{__ 
_readStdoutTask`` 
.`` 
Wait`` 
(`` 
)`` 
;`` 
_readStderrTaskaa 
.aa 
Waitaa 
(aa 
)aa 
;aa 
}bb 
publicdd 
voiddd	 
Disposedd 
(dd 
)dd 
{ee 
ifff 
(ff 
_readStdoutTaskff 
!=ff 
nullff 
)ff 
_readStdoutTaskff  /
.ff/ 0
Disposeff0 7
(ff7 8
)ff8 9
;ff9 :
ifgg 
(gg 
_readStderrTaskgg 
!=gg 
nullgg 
)gg 
_readStderrTaskgg  /
.gg/ 0
Disposegg0 7
(gg7 8
)gg8 9
;gg9 :
}hh 
privatejj 	
voidjj
 
ReadStdoutAsyncjj 
(jj 
)jj  
{kk 
ReadStdAsyncll 
(ll 
_stdoutll 
)ll 
;ll 
}mm 
privateoo 	
voidoo
 
ReadStderrAsyncoo 
(oo 
)oo  
{pp 
ReadStdAsyncqq 
(qq 
_stderrqq 
,qq 
$strqq #
)qq# $
;qq$ %
}rr 
privatett 	
voidtt
 
ReadStdAsynctt 
(tt 

TextReadertt &
outputtt' -
,tt- .
stringtt/ 5
prefixtt6 <
=tt= >
nulltt? C
)ttC D
{uu 
stringvv 	
linevv
 
;vv 
whileww 
(ww	 

(ww
 
lineww 
=ww 
outputww 
.ww 
ReadLineww !
(ww! "
)ww" #
)ww# $
!=ww% '
nullww( ,
)ww, -
{xx 
ifyy 
(yy 
prefixyy 
!=yy 
nullyy 
)yy 
lineyy 
=yy 
prefixyy %
+yy& '
lineyy( ,
;yy, -
Debug{{ 	
.{{	 

	WriteLine{{
 
({{ 
$str{{ 
+{{  
line{{! %
){{% &
;{{& '
_pendingOutputLines}} 
.}} 
Add}} 
(}} 
line}}  
)}}  !
;}}! "
}~~ 
} 
}
ÄÄ 
}ÅÅ ”*
6D:\Student\sonar\diplom-master\SikuliSharp\Patterns.cs
	namespace 	
SikuliSharp
 
{ 
public 
class 
Patterns 
{ 
public		 
const			 
float		 
DefaultSimilarity		 &
=		' (
$num		) -
;		- .
public 
static	 
IPattern 
FromFile !
(! "
string" (
path) -
,- .
float/ 4

similarity5 ?
=@ A
DefaultSimilarityB S
)S T
{ 
return 	
new
 
FilePattern 
( 
path 
, 

similarity  *
)* +
;+ ,
} 
} 
public 
	interface 
IPattern 
{ 
void 
Validate 
( 
) 
; 
string 
ToSikuliScript	 
( 
) 
; 
} 
public 
class 
FilePattern 
: 
IPattern $
{ 
private 	
readonly
 
string 
_path 
;  
private 	
readonly
 
float 
_similarity $
;$ %
public 
FilePattern	 
( 
string 
path  
,  !
float" '

similarity( 2
)2 3
{ 
if 
( 
path 
== 
null 
) 
throw 
new !
ArgumentNullException 4
(4 5
$str5 ;
); <
;< =
if 
( 

similarity 
< 
$num 
|| 

similarity #
>$ %
$num& '
)' (
throw) .
new/ 2'
ArgumentOutOfRangeException3 N
(N O
$strO [
,[ \

similarity] g
,g h
$str	i ç
)
ç é
;
é è
_path!! 
=!!	 

path!! 
;!! 
_similarity"" 
="" 

similarity"" 
;"" 
}## 
public%% 
void%%	 
Validate%% 
(%% 
)%% 
{&& 
if'' 
('' 
!'' 
File'' 
.'' 
Exists'' 
('' 
_path'' 
)'' 
)'' 
throw(( 	
new((
 !
FileNotFoundException(( #
(((# $
$str(($ V
+((W X
_path((Y ^
,((^ _
_path((` e
)((e f
;((f g
})) 
public++ 
string++	 
ToSikuliScript++ 
(++ 
)++  
{,, 
return-- 	
string--
 
.-- 
Format-- 
(-- 
NumberFormatInfo-- (
.--( )
InvariantInfo--) 6
,--6 7
$str--8 W
,--W X
_path--Y ^
.--^ _
Replace--_ f
(--f g
$str--g k
,--k l
$str--m r
)--r s
,--s t
_similarity	--u Ä
.
--Ä Å
ToString
--Å â
(
--â ä
CultureInfo
--ä ï
.
--ï ñ
InvariantCulture
--ñ ¶
)
--¶ ß
)
--ß ®
;
--® ©
}.. 
}// 
public11 
class11 
WithOffsetPattern11 
:11  !
IPattern11" *
{22 
private33 	
readonly33
 
IPattern33 
_pattern33 $
;33$ %
private44 	
readonly44
 
Point44 
_offset44  
;44  !
public66 
WithOffsetPattern66	 
(66 
IPattern66 #
pattern66$ +
,66+ ,
Point66- 2
offset663 9
)669 :
{77 
if88 
(88 
pattern88 
==88 
null88 
)88 
throw88 
new88 !!
ArgumentNullException88" 7
(887 8
$str888 A
)88A B
;88B C
_pattern99 
=99 
pattern99 
;99 
_offset:: 

=:: 
offset:: 
;:: 
};; 
public== 
void==	 
Validate== 
(== 
)== 
{>> 
if?? 
(?? 
_pattern?? 
is?? 
WithOffsetPattern?? #
)??# $
throw@@ 	
new@@
 
	Exception@@ 
(@@ 
$str@@ B
)@@B C
;@@C D
_patternBB 
.BB 
ValidateBB 
(BB 
)BB 
;BB 
}CC 
publicEE 
stringEE	 
ToSikuliScriptEE 
(EE 
)EE  
{FF 
returnGG 	
stringGG
 
.GG 
FormatGG 
(GG 
$strGG 4
,GG4 5
_patternGG6 >
.GG> ?
ToSikuliScriptGG? M
(GGM N
)GGN O
,GGO P
_offsetGGQ X
.GGX Y
XGGY Z
,GGZ [
_offsetGG\ c
.GGc d
YGGd e
)GGe f
;GGf g
}HH 
}II 
}JJ §
3D:\Student\sonar\diplom-master\SikuliSharp\Point.cs
	namespace 	
SikuliSharp
 
{ 
public 
struct 
Point 
{ 
public 
int 
X 
{ 
get 
; 
set 
; 
} 
public 
int 
Y 
{ 
get 
; 
set 
; 
} 
public 
Point 
( 
int 
x 
, 
int 
y  !
)! "
{		 
X

 
=

 
x

 
;

 	
Y 
= 
y 
; 	
} 
} 
} ã
ED:\Student\sonar\diplom-master\SikuliSharp\Properties\AssemblyInfo.cs
[ 
assembly 	
:	 

AssemblyTitle 
( 
$str &
)& '
]' (
[ 
assembly 	
:	 

AssemblyDescription 
( 
$str 8
)8 9
]9 :
[ 
assembly 	
:	 
!
AssemblyConfiguration  
(  !
$str! #
)# $
]$ %
[ 
assembly 	
:	 

AssemblyCompany 
( 
$str .
). /
]/ 0
[ 
assembly 	
:	 

AssemblyProduct 
( 
$str (
)( )
]) *
[		 
assembly		 	
:			 

AssemblyCopyright		 
(		 
$str		 A
)		A B
]		B C
[

 
assembly

 	
:

	 

AssemblyTrademark

 
(

 
$str

 
)

  
]

  !
[ 
assembly 	
:	 

AssemblyCulture 
( 
$str 
) 
] 
[ 
assembly 	
:	 


ComVisible 
( 
false 
) 
] 
[ 
assembly 	
:	 

Guid 
( 
$str 6
)6 7
]7 8
[ 
assembly 	
:	 

AssemblyVersion 
( 
$str $
)$ %
]% &
[ 
assembly 	
:	 

AssemblyFileVersion 
( 
$str (
)( )
]) *
[ 
assembly 	
:	 
(
AssemblyInformationalVersion '
(' (
$str( 1
)1 2
]2 3˜
4D:\Student\sonar\diplom-master\SikuliSharp\Sikuli.cs
	namespace 	
SikuliSharp
 
{ 
public 
static 
class 
Sikuli 
{ 
public 
static	 
ISikuliSession 
CreateSession ,
(, -
)- .
{		 
return

 	
new


 
SikuliSession

 
(

 
CreateRuntime

 )
(

) *
)

* +
)

+ ,
;

, -
} 
public 
static	 
SikuliRuntime 
CreateRuntime +
(+ ,
), -
{ 
return 	
new
 
SikuliRuntime 
( 
new ,
 AsyncDuplexStreamsHandlerFactory (
(( )
)) *
,* +
new &
SikuliScriptProcessFactory "
(" #
)# $
) 
; 
} 
public 
static	 
string 

RunProject !
(! "
string" (
projectPath) 4
)4 5
{ 
return 	

RunProject
 
( 
projectPath  
,  !
null" &
)& '
;' (
} 
public 
static	 
string 

RunProject !
(! "
string" (
projectPath) 4
,4 5
string6 <
args= A
)A B
{ 
if 
( 
projectPath 
== 
null 
) 
throw !
new" %!
ArgumentNullException& ;
(; <
$str< I
)I J
;J K
if 
( 
! 
	Directory 
. 
Exists 
( 
projectPath $
)$ %
)% &
throw 	
new
 &
DirectoryNotFoundException (
(( )
string) /
./ 0
Format0 6
(6 7
$str7 X
,X Y
projectPathZ e
)e f
)f g
;g h
var!! 
processFactory!! 
=!! 
new!! &
SikuliScriptProcessFactory!! 6
(!!6 7
)!!7 8
;!!8 9
using"" 
(""	 

var""
 
process"" 
="" 
processFactory"" &
.""& '
Start""' ,
("", -
string""- 3
.""3 4
Format""4 :
("": ;
$str""; G
,""G H
projectPath""I T
,""T U
args""V Z
)""Z [
)""[ \
)""\ ]
{## 
var$$ 
output$$ 
=$$ 
process$$ 
.$$ 
StandardOutput$$ '
.$$' (
	ReadToEnd$$( 1
($$1 2
)$$2 3
;$$3 4
process%% 
.%% 
WaitForExit%% 
(%% 
)%% 
;%% 
return&& 

output&& 
;&& 
}'' 
}(( 
})) 
}** ˘
=D:\Student\sonar\diplom-master\SikuliSharp\SikuliException.cs
	namespace 	
SikuliSharp
 
{ 
public 
class 
SikuliException 
: 
	Exception  )
{ 
public 
SikuliException	 
( 
string 
message  '
)' (
: 
base 	
(	 

message
 
) 
{		 
}

 
} 
} ù
GD:\Student\sonar\diplom-master\SikuliSharp\SikuliFindFailedException.cs
	namespace 	
SikuliSharp
 
{ 
public 
class %
SikuliFindFailedException '
:( )
SikuliException* 9
{ 
public %
SikuliFindFailedException	 "
(" #
string# )
message* 1
)1 2
: 
base 	
(	 

message
 
) 
{ 
} 
}		 
}

 ÌG
;D:\Student\sonar\diplom-master\SikuliSharp\SikuliRuntime.cs
	namespace 	
SikuliSharp
 
{ 
public 
	interface 
ISikuliRuntime  
:! "
IDisposable# .
{ 
void 
Start 
( 
) 
; 
void		 
Stop		 
(		 
bool		 
ignoreErrors		 
=		 
false		  %
)		% &
;		& '
string

 
Run

	 
(

 
string

 
command

 
,

 
string

 #
resultPrefix

$ 0
,

0 1
double

2 8
timeoutInSeconds

9 I
)

I J
;

J K
} 
public 
class 
SikuliRuntime 
: 
ISikuliRuntime ,
{ 
private 	
readonly
 -
!IAsyncDuplexStreamsHandlerFactory 4-
!_asyncDuplexStreamsHandlerFactory5 V
;V W
private 	
Process
 
_process 
; 
private 	&
IAsyncTwoWayStreamsHandler
 $&
_asyncTwoWayStreamsHandler% ?
;? @
private 	
readonly
 '
ISikuliScriptProcessFactory .'
_sikuliScriptProcessFactory/ J
;J K
private 	
const
 
string )
InteractiveConsoleReadyMarker 4
=5 6
$str7 Z
;Z [
private 	
const
 
string 
ErrorMarker "
=# $
$str% .
;. /
private 	
const
 
string 
ExitCommand "
=# $
$str% -
;- .
private 	
const
 
int %
SikuliReadyTimeoutSeconds -
=. /
$num0 2
;2 3
public 
SikuliRuntime	 
( -
!IAsyncDuplexStreamsHandlerFactory 8,
 asyncDuplexStreamsHandlerFactory9 Y
,Y Z'
ISikuliScriptProcessFactory[ v'
sikuliScriptProcessFactory	w ë
)
ë í
{ 
if 
( ,
 asyncDuplexStreamsHandlerFactory '
==( *
null+ /
)/ 0
throw1 6
new7 :!
ArgumentNullException; P
(P Q
$strQ s
)s t
;t u
if 
( &
sikuliScriptProcessFactory !
==" $
null% )
)) *
throw+ 0
new1 4!
ArgumentNullException5 J
(J K
$strK g
)g h
;h i-
!_asyncDuplexStreamsHandlerFactory $
=% &,
 asyncDuplexStreamsHandlerFactory' G
;G H'
_sikuliScriptProcessFactory 
=  &
sikuliScriptProcessFactory! ;
;; <
} 
public!! 
void!!	 
Start!! 
(!! 
)!! 
{"" 
if## 
(## 
_process## 
!=## 
null## 
)## 
throw## 
new## "%
InvalidOperationException### <
(##< =
$str##= k
)##k l
;##l m
_process%% 
=%% '
_sikuliScriptProcessFactory%% )
.%%) *
Start%%* /
(%%/ 0
$str%%0 4
)%%4 5
;%%5 6&
_asyncTwoWayStreamsHandler'' 
='' -
!_asyncDuplexStreamsHandlerFactory''  A
.''A B
Create''B H
(''H I
_process''I Q
.''Q R
StandardOutput''R `
,''` a
_process''b j
.''j k
StandardError''k x
,''x y
_process	''z Ç
.
''Ç É
StandardInput
''É ê
)
''ê ë
;
''ë í&
_asyncTwoWayStreamsHandler(( 
.(( 
	ReadUntil(( '
(((' (%
SikuliReadyTimeoutSeconds((( A
,((A B)
InteractiveConsoleReadyMarker((C `
)((` a
;((a b
})) 
public++ 
void++	 
Stop++ 
(++ 
bool++ 
ignoreErrors++ $
=++% &
false++' ,
)++, -
{,, 
if-- 
(-- 
_process-- 
==-- 
null-- 
)-- 
return-- 
;--  &
_asyncTwoWayStreamsHandler// 
.// 
	WriteLine// '
(//' (
ExitCommand//( 3
)//3 4
;//4 5
if11 
(11 
!11 
_process11 
.11 
	HasExited11 
)11 
{22 
if33 
(33 
!33 	
_process33	 
.33 
WaitForExit33 
(33 
$num33 !
)33! "
)33" #
_process44 
.44 
Kill44 
(44 
)44 
;44 
}55 
string77 	
errors77
 
=77 
null77 
;77 
if88 
(88 
!88 
ignoreErrors88 
)88 
errors99 

=99 
_process99 
.99 
StandardError99 #
.99# $
	ReadToEnd99$ -
(99- .
)99. /
;99/ 0&
_asyncTwoWayStreamsHandler;; 
.;; 
WaitForExit;; )
(;;) *
);;* +
;;;+ ,&
_asyncTwoWayStreamsHandler== 
.== 
Dispose== %
(==% &
)==& '
;==' (&
_asyncTwoWayStreamsHandler>> 
=>> 
null>>  $
;>>$ %
_process?? 
.?? 
Dispose?? 
(?? 
)?? 
;?? 
_process@@ 
=@@ 
null@@ 
;@@ 
ifBB 
(BB 
!BB 
ignoreErrorsBB 
&&BB 
!BB 
StringBB 
.BB  
IsNullOrEmptyBB  -
(BB- .
errorsBB. 4
)BB4 5
)BB5 6
throwCC 	
newCC
 
SikuliExceptionCC 
(CC 
$strCC /
+CC0 1
errorsCC2 8
)CC8 9
;CC9 :
}DD 
publicFF 
stringFF	 
RunFF 
(FF 
stringFF 
commandFF "
,FF" #
stringFF$ *
resultPrefixFF+ 7
,FF7 8
doubleFF9 ?
timeoutInSecondsFF@ P
)FFP Q
{GG 
ifHH 
(HH 
_processHH 
==HH 
nullHH 
||HH 
_processHH "
.HH" #
	HasExitedHH# ,
)HH, -
throwII 	
newII
 %
InvalidOperationExceptionII '
(II' (
$strII( K
)IIK L
;IIL M
DebugLL 
.LL 	
	WriteLineLL	 
(LL 
commandLL 
)LL 
;LL &
_asyncTwoWayStreamsHandlerNN 
.NN 
	WriteLineNN '
(NN' (
commandNN( /
)NN/ 0
;NN0 1&
_asyncTwoWayStreamsHandlerOO 
.OO 
	WriteLineOO '
(OO' (
$strOO( *
)OO* +
;OO+ ,&
_asyncTwoWayStreamsHandlerPP 
.PP 
	WriteLinePP '
(PP' (
$strPP( *
)PP* +
;PP+ ,
varRR 
resultRR 
=RR &
_asyncTwoWayStreamsHandlerRR *
.RR* +
	ReadUntilRR+ 4
(RR4 5
timeoutInSecondsRR5 E
,RRE F
ErrorMarkerRRG R
,RRR S
resultPrefixRRT `
)RR` a
;RRa b
ifTT 
(TT 
resultTT 
.TT 
IndexOfTT 
(TT 
ErrorMarkerTT !
,TT! "
StringComparisonTT# 3
.TT3 4
OrdinalTT4 ;
)TT; <
>TT= >
-TT? @
$numTT@ A
)TTA B
{UU 
resultVV 

=VV 
resultVV 
+VV 
EnvironmentVV !
.VV! "
NewLineVV" )
+VV* +
stringVV, 2
.VV2 3
JoinVV3 7
(VV7 8
EnvironmentVV8 C
.VVC D
NewLineVVD K
,VVK L&
_asyncTwoWayStreamsHandlerVVM g
.VVg h
ReadUpToNowVVh s
(VVs t
$numVVt x
)VVx y
)VVy z
;VVz {
ifWW 
(WW 
resultWW 
.WW 
ContainsWW 
(WW 
$strWW $
)WW$ %
)WW% &
throwXX 

newXX %
SikuliFindFailedExceptionXX (
(XX( )
resultXX) /
)XX/ 0
;XX0 1
throwYY 	
newYY
 
SikuliExceptionYY 
(YY 
resultYY $
)YY$ %
;YY% &
}ZZ 
return\\ 	
result\\
 
;\\ 
}]] 
public__ 
void__	 
Dispose__ 
(__ 
)__ 
{`` 
Stopaa 
(aa 
trueaa 
)aa 
;aa 
}bb 
}cc 
}dd  @
HD:\Student\sonar\diplom-master\SikuliSharp\SikuliScriptProcessFactory.cs
	namespace 	
SikuliSharp
 
{ 
public 
	interface '
ISikuliScriptProcessFactory -
{		 
Process

 	
Start


 
(

 
string

 
args

 
)

 
;

 
} 
public 
class &
SikuliScriptProcessFactory (
:) *'
ISikuliScriptProcessFactory+ F
{ 
public 
Process	 
Start 
( 
string 
args "
)" #
{ 
var 
javaPath 
= 
GuessJavaPath 
(  
)  !
;! "
var 

sikuliHome 
= 
MakeEmptyNull !
(! "
Environment" -
.- ."
GetEnvironmentVariable. D
(D E
$strE R
)R S
)S T
;T U
if 
( 

sikuliHome 
== 
null 
) 
throw  
new! $
	Exception% .
(. /
$str	/ à
)
à â
;
â ä
var 
sikuliScriptJarPath 
= 
DetectSikuliPath -
(- .

sikuliHome. 8
)8 9
;9 :
var 
javaArguments 
= 
string 
. 
Format $
($ %
$str% 7
,7 8
sikuliScriptJarPath9 L
,L M
argsN R
)R S
;S T
Debug 
. 	
	WriteLine	 
( 
$str )
+* +
javaPath, 4
+5 6
$str7 <
+= >
javaArguments? L
)L M
;M N
var 
process 
= 
new 
Process 
{ 
	StartInfo 
= 
{ 
FileName 
= 
javaPath 
, 
	Arguments   
=   
javaArguments   
,   
CreateNoWindow!! 
=!! 
true!! 
,!! 
WindowStyle"" 
="" 
ProcessWindowStyle"" %
.""% &
Hidden""& ,
,"", -
UseShellExecute## 
=## 
false## 
,## !
RedirectStandardInput$$ 
=$$ 
true$$ !
,$$! "!
RedirectStandardError%% 
=%% 
true%% !
,%%! ""
RedirectStandardOutput&& 
=&& 
true&& "
}'' 
}(( 
;(( 
process** 

.**
 
Start** 
(** 
)** 
;** 
return,, 	
process,,
 
;,, 
}-- 
private// 	
static//
 
string// 
DetectSikuliPath// (
(//( )
string//) /

sikuliHome//0 :
)//: ;
{00 
var11 "
sikuliScript101JarPath11 
=11 
Path11  $
.11$ %
Combine11% ,
(11, -

sikuliHome11- 7
,117 8
$str119 L
)11L M
;11M N
if22 
(22 
File22 
.22 
Exists22 
(22 "
sikuliScript101JarPath22 )
)22) *
)22* +
return33 
"
sikuliScript101JarPath33 !
;33! "
var55 "
sikuliScript110JarPath55 
=55 
Path55  $
.55$ %
Combine55% ,
(55, -

sikuliHome55- 7
,557 8
$str559 F
)55F G
;55G H
if66 
(66 
File66 
.66 
Exists66 
(66 "
sikuliScript110JarPath66 )
)66) *
)66* +
return77 
"
sikuliScript110JarPath77 !
;77! "
throw99 
new99	 !
FileNotFoundException99 "
(99" #
string:: 

.::
 
Format:: 
(:: 
$str	:: ã
,
::ã å

sikuliHome
::ç ó
)
::ó ò
)
::ò ô
;
::ô ö
};; 
public== 
static==	 
string== 
GuessJavaPath== $
(==$ %
)==% &
{>> 
var?? 
javaHome?? 
=?? 
MakeEmptyNull?? 
(??  
Environment??  +
.??+ ,"
GetEnvironmentVariable??, B
(??B C
$str??C N
)??N O
)??O P
??@@	 
MakeEmptyNull@@ 
(@@ #
GetJavaPathFromRegistry@@ 1
(@@1 2
RegistryView@@2 >
.@@> ?

Registry64@@? I
)@@I J
)@@J K
??AA	 
MakeEmptyNullAA 
(AA #
GetJavaPathFromRegistryAA 1
(AA1 2
RegistryViewAA2 >
.AA> ?

Registry32AA? I
)AAI J
)AAJ K
;AAK L
ifCC 
(CC 
StringCC 
.CC 
IsNullOrEmptyCC 
(CC 
javaHomeCC $
)CC$ %
)CC% &
throwDD 	
newDD
 
	ExceptionDD 
(DD 
$strDD o
)DDo p
;DDp q
varFF 
javaPathFF 
=FF 
PathFF 
.FF 
CombineFF 
(FF 
javaHomeFF '
,FF' (
$strFF) .
,FF. /
$strFF0 :
)FF: ;
;FF; <
ifHH 
(HH 
!HH 
FileHH 
.HH 
ExistsHH 
(HH 
javaPathHH 
)HH 
)HH 
throwII 	
newII
 
	ExceptionII 
(II 
stringII 
.II 
FormatII %
(II% &
$str	II& ª
,
IIª º
javaPath
IIΩ ≈
)
II≈ ∆
)
II∆ «
;
II« »
returnKK 	
javaPathKK
 
;KK 
}LL 
publicNN 
staticNN	 
stringNN #
GetJavaPathFromRegistryNN .
(NN. /
RegistryViewNN/ ;
viewNN< @
)NN@ A
{OO 
constPP 
stringPP	 
jreKeyPP 
=PP 
$strPP G
;PPG H
usingQQ 
(QQ	 

varQQ
 
baseKeyQQ 
=QQ 
RegistryKeyQQ #
.QQ# $
OpenBaseKeyQQ$ /
(QQ/ 0
RegistryHiveQQ0 <
.QQ< =
LocalMachineQQ= I
,QQI J
viewQQK O
)QQO P
.QQP Q

OpenSubKeyQQQ [
(QQ[ \
jreKeyQQ\ b
)QQb c
)QQc d
{RR 
ifSS 
(SS 
baseKeySS 
==SS 
nullSS 
)SS 
returnTT 
nullTT 
;TT 
varVV 
currentVersionVV 
=VV 
baseKeyVV  
.VV  !
GetValueVV! )
(VV) *
$strVV* :
)VV: ;
.VV; <
ToStringVV< D
(VVD E
)VVE F
;VVF G
usingWW 	
(WW
 
varWW 
homeKeyWW 
=WW 
baseKeyWW  
.WW  !

OpenSubKeyWW! +
(WW+ ,
currentVersionWW, :
)WW: ;
)WW; <
{XX 
ifYY 
(YY 	
homeKeyYY	 
!=YY 
nullYY 
)YY 
returnYY  
homeKeyYY! (
.YY( )
GetValueYY) 1
(YY1 2
$strYY2 <
)YY< =
.YY= >
ToStringYY> F
(YYF G
)YYG H
;YYH I
}ZZ 
}[[ 
return\\ 	
null\\
 
;\\ 
}]] 
private__ 	
static__
 
string__ 
MakeEmptyNull__ %
(__% &
string__& ,
value__- 2
)__2 3
{`` 
returnaa 	
valueaa
 
==aa 
$straa 
?aa 
nullaa 
:aa 
valueaa $
;aa$ %
}bb 
}cc 
}dd ıV
;D:\Student\sonar\diplom-master\SikuliSharp\SikuliSession.cs
	namespace 	
SikuliSharp
 
{ 
public 
	interface 
ISikuliSession  
:! "
IDisposable# .
{ 
bool 
Exists 
( 
IPattern 
pattern 
, 
float  %
timeoutInSeconds& 6
=7 8
$num9 :
): ;
;; <
bool		 
Click		 
(		 
IPattern		 
pattern		 
)		 
;		 
bool

 
Click

 
(

 
IPattern

 
pattern

 
,

 
Point

 $
offset

% +
)

+ ,
;

, -
bool 
DoubleClick 
( 
IPattern 
pattern #
)# $
;$ %
bool 
DoubleClick 
( 
IPattern 
pattern #
,# $
Point% *
offset+ 1
)1 2
;2 3
bool 
Wait 
( 
IPattern 
pattern 
, 
float #
timeoutInSeconds$ 4
=5 6
$num7 8
)8 9
;9 :
bool 

WaitVanish 
( 
IPattern 
pattern "
," #
float$ )
timeoutInSeconds* :
=; <
$num= >
)> ?
;? @
bool 
Type 
( 
string 
text 
) 
; 
bool 
DragAndDrop 
( 
IPattern !
pattern" )
,) *
IPattern+ 3
pattern24 <
)< =
;= >
bool 
Hover 
( 
IPattern 
pattern #
)# $
;$ %
} 
public 
class 
SikuliSession 
: 
ISikuliSession ,
{ 
private 	
static
 
readonly 
Regex 
InvalidTextRegex  0
=1 2
new3 6
Regex7 <
(< =
$str= Q
,Q R
RegexOptionsS _
._ `
Compiled` h
)h i
;i j
private 	
readonly
 
ISikuliRuntime !
_runtime" *
;* +
public 
SikuliSession	 
( 
ISikuliRuntime %
sikuliRuntime& 3
)3 4
{ 
_runtime 
= 
sikuliRuntime 
; 
_runtime 
. 
Start 
( 
) 
; 
} 
public 
bool 
Hover 
( 
IPattern "
pattern# *
)* +
{   	
return!! 

RunCommand!! 
(!! 
$str!! %
,!!% &
pattern!!' .
,!!. /
$num!!0 1
)!!1 2
;!!2 3
}"" 	
public$$ 
bool$$ 
DragAndDrop$$ 
($$  
IPattern$$  (
pattern$$) 0
,$$0 1
IPattern$$2 :
pattern2$$; C
)$$C D
{%% 	
return&& 
RunCommand2Param&& #
(&&# $
$str&&$ .
,&&. /
pattern&&0 7
,&&7 8
pattern2&&9 A
,&&A B
$num&&C D
)&&D E
;&&E F
}'' 	
public)) 
bool)) 
Exists)) 
()) 
IPattern)) #
pattern))$ +
,))+ ,
float))- 2
timeoutInSeconds))3 C
=))D E
$num))F H
)))H I
{** 
return++ 	

RunCommand++
 
(++ 
$str++ 
,++ 
pattern++ &
,++& '
timeoutInSeconds++( 8
)++8 9
;++9 :
},, 
public.. 
bool..	 
Click.. 
(.. 
IPattern.. 
pattern.. $
)..$ %
{// 
return00 	

RunCommand00
 
(00 
$str00 
,00 
pattern00 %
,00% &
$num00' (
)00( )
;00) *
}11 
public33 
bool33	 
Click33 
(33 
IPattern33 
pattern33 $
,33$ %
Point33& +
offset33, 2
)332 3
{44 
return55 	

RunCommand55
 
(55 
$str55 
,55 
new55 !
WithOffsetPattern55" 3
(553 4
pattern554 ;
,55; <
offset55= C
)55C D
,55D E
$num55F G
)55G H
;55H I
}66 
public88 
bool88	 
DoubleClick88 
(88 
IPattern88 "
pattern88# *
)88* +
{99 
return:: 	

RunCommand::
 
(:: 
$str:: "
,::" #
pattern::$ +
,::+ ,
$num::- .
)::. /
;::/ 0
};; 
public== 
bool==	 
DoubleClick== 
(== 
IPattern== "
pattern==# *
,==* +
Point==, 1
offset==2 8
)==8 9
{>> 
return?? 	

RunCommand??
 
(?? 
$str?? "
,??" #
new??$ '
WithOffsetPattern??( 9
(??9 :
pattern??: A
,??A B
offset??C I
)??I J
,??J K
$num??L M
)??M N
;??N O
}@@ 
publicBB 
boolBB	 
WaitBB 
(BB 
IPatternBB 
patternBB #
,BB# $
floatBB% *
timeoutInSecondsBB+ ;
=BB< =
$numBB> @
)BB@ A
{CC 
returnDD 	

RunCommandDD
 
(DD 
$strDD 
,DD 
patternDD $
,DD$ %
timeoutInSecondsDD& 6
)DD6 7
;DD7 8
}EE 
publicGG 
boolGG	 

WaitVanishGG 
(GG 
IPatternGG !
patternGG" )
,GG) *
floatGG+ 0
timeoutInSecondsGG1 A
=GGB C
$numGGD F
)GGF G
{HH 
returnII 	

RunCommandII
 
(II 
$strII !
,II! "
patternII# *
,II* +
timeoutInSecondsII, <
)II< =
;II= >
}JJ 
publicLL 
boolLL	 
TypeLL 
(LL 
stringLL 
textLL 
)LL 
{MM 
ifNN 
(NN 
InvalidTextRegexNN 
.NN 
IsMatchNN 
(NN 
textNN #
)NN# $
)NN$ %
throwOO 	
newOO
 
ArgumentExceptionOO 
(OO  
$strOO  v
,OOv w
$strOOx ~
)OO~ 
;	OO Ä
varQQ 
scriptQQ 
=QQ 
stringQQ 
.QQ 
FormatQQ 
(QQ 
$strRR G
,RRG H
textSS 
)TT 
;TT 
varVV 
resultVV 
=VV 
_runtimeVV 
.VV 
RunVV 
(VV 
scriptVV #
,VV# $
$strVV% 0
,VV0 1
$numVV2 4
)VV4 5
;VV5 6
returnWW 	
resultWW
 
.WW 
ContainsWW 
(WW 
$strWW (
)WW( )
;WW) *
}XX 
	protectedZZ 
boolZZ 

RunCommandZZ 
(ZZ 
stringZZ "
commandZZ# *
,ZZ* +
IPatternZZ, 4
patternZZ5 <
,ZZ< =
floatZZ> C
commandParameterZZD T
)ZZT U
{[[ 
pattern\\ 

.\\
 
Validate\\ 
(\\ 
)\\ 
;\\ 
var^^ 
script^^ 
=^^ 
string^^ 
.^^ 
Format^^ 
(^^ 
$str__ @
,__@ A
command`` 
,`` 
patternaa 
.aa 
ToSikuliScriptaa 
(aa 
)aa 
,aa 
ToSukuliFloatbb 
(bb 
commandParameterbb "
)bb" #
)cc 
;cc 
varee 
resultee 
=ee 
_runtimeee 
.ee 
Runee 
(ee 
scriptee #
,ee# $
$stree% 0
,ee0 1
commandParameteree2 B
*eeC D
$numeeE I
)eeI J
;eeJ K
returnff 	
resultff
 
.ff 
Containsff 
(ff 
$strff (
)ff( )
;ff) *
}gg 
	protectedii 
boolii 
RunCommand2Paramii '
(ii' (
stringii( .
commandii/ 6
,ii6 7
IPatternii8 @
patterniiA H
,iiH I
IPatterniiJ R
pattern2iiS [
,ii[ \
floatii] b
commandParameteriic s
)iis t
{jj 	
patternkk 
.kk 
Validatekk 
(kk 
)kk 
;kk 
varmm 
scriptmm 
=mm 
stringmm 
.mm  
Formatmm  &
(mm& '
$strnn S
,nnS T
commandoo 
,oo 
patternpp 
.pp 
ToSikuliScriptpp &
(pp& '
)pp' (
,pp( )
pattern2qq 
.qq 
ToSikuliScriptqq '
(qq' (
)qq( )
,qq) *
ToSukuliFloatrr 
(rr 
commandParameterrr .
)rr. /
)ss 
;ss 
varuu 
resultuu 
=uu 
_runtimeuu !
.uu! "
Runuu" %
(uu% &
scriptuu& ,
,uu, -
$struu. 9
,uu9 :
commandParameteruu; K
*uuL M
$numuuN R
)uuR S
;uuS T
returnvv 
resultvv 
.vv 
Containsvv "
(vv" #
$strvv# 1
)vv1 2
;vv2 3
}ww 	
privatezz 
staticzz 
stringzz 
ToSukuliFloatzz +
(zz+ ,
floatzz, 1
timeoutInSecondszz2 B
)zzB C
{{{ 
return|| 	
timeoutInSeconds||
 
>|| 
$num|| 
?||  !
$str||" &
+||' (
timeoutInSeconds||) 9
.||9 :
ToString||: B
(||B C
$str||C K
)||K L
:||M N
$str||O Q
;||Q R
}}} 
public 
void	 
Dispose 
( 
) 
{
ÄÄ 
_runtime
ÅÅ 
.
ÅÅ 
Stop
ÅÅ 
(
ÅÅ 
)
ÅÅ 
;
ÅÅ 
}
ÇÇ 
}
ÉÉ 
}ÑÑ 