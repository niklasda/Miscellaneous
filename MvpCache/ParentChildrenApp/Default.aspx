<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="nida.ui.UserList" %>
<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Default Page</title>
</head>

<body>
   <form id="form1" runat="server">
      <div>
         <anthem:DataList ID="UserDataList" DataKeyField="ParentId" runat="server" Width="100%"
            AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True">
            <HeaderTemplate>
               <table border="0" width="100%" cellpadding="0" cellspacing="0">
                  <tr style="color: White; background-color: Black">
                     <td>
                        &nbsp;</td>
                     <td>
                        Name</td>
                     <td>
                        Last time of Login</td>
                  </tr>
            </HeaderTemplate>
            <ItemTemplate>
               <tr>
                  <td >
                     <anthem:LinkButton ID="ExpandButton" runat="server" OnClick="ExpandButton_Click"
                        Text="Show" CommandArgument='<%# Eval("ParentId") %>' TextDuringCallBack="..."></anthem:LinkButton></td>
                  <td >
                     <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label></td>
                  <td >
                     <asp:Label ID="lblLastLogin" runat="server" Text='<%# Eval("LastLogin") %>'></asp:Label></td>
               </tr>
               <tr>
                  <td colspan="4" align="left" width="100%">
                     <anthem:DataList ID="UserDetailsDataList" runat="server" AutoUpdateAfterCallBack="true"
                        Visible="False" Width="100%">
                        <HeaderTemplate>
                           <table width="100%">
                        </HeaderTemplate>
                        <ItemTemplate>
                           <tr>
                              <td>
                                 <asp:Label ID="lblName" runat="server" Text='<%# "<b>Name:</b> " + Eval("Name") %>'></asp:Label>
                                 &nbsp;&nbsp;&nbsp;
                                 <asp:Label ID="lblAge" runat="server" Text='<%# "<b>Age</b>: " + Eval("Age") %>'></asp:Label>
                                 <br />
                              </td>
                           </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                           </table></FooterTemplate>
                     </anthem:DataList>
                  </td>
               </tr>
            </ItemTemplate>
            <FooterTemplate>
               </table>
            </FooterTemplate>
         </anthem:DataList>
        
<br />
Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Sed in diam in pede ultrices facilisis. Praesent neque. Nulla in sapien. Pellentesque non nisl non lacus volutpat sodales. Proin ornare aliquam mauris. Duis condimentum elit volutpat tellus. Curabitur est. Phasellus euismod lorem. Vivamus sodales, arcu tristique facilisis rhoncus, purus dui commodo nulla, in pellentesque tortor erat non risus. Fusce interdum scelerisque purus. Fusce leo massa, tempor gravida, varius non, convallis id, mauris. Sed suscipit. Maecenas sit amet tortor at ligula ullamcorper scelerisque. Vestibulum vehicula. Etiam tristique. In hac habitasse platea dictumst. Praesent quis elit. Proin semper venenatis dolor. Phasellus at urna. Integer varius nonummy lorem. 

Etiam vitae augue a dolor cursus placerat. Sed sit amet mi ut leo accumsan rhoncus. Sed sodales feugiat tortor. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Fusce eget mauris. Pellentesque mollis velit nec mauris. Nunc a nisi id turpis iaculis ullamcorper. Sed leo tellus, mollis at, varius sed, gravida ac, eros. Phasellus ultrices sem quis magna. Mauris sem. Pellentesque non risus at nisi pellentesque consequat. Aenean est. Mauris ac nisi. 

Suspendisse a nunc. Nullam dapibus tempor neque. In fringilla. Pellentesque sollicitudin quam ut augue. In in urna non tortor congue mollis. Sed porttitor pharetra magna. Sed tristique, quam vel condimentum pharetra, mi libero malesuada lorem, ut fermentum dolor massa ac ipsum. Ut diam lacus, adipiscing sit amet, varius at, fringilla quis, dolor. Sed leo nulla, placerat a, hendrerit ut, pellentesque eu, tortor. Nam interdum ipsum vitae enim. Sed odio mi, euismod in, aliquet ac, sollicitudin eget, risus. 

Aliquam felis felis, posuere at, blandit at, luctus ut, turpis. Donec mi. Curabitur laoreet elit nec enim. Curabitur sit amet augue nec lorem scelerisque ultricies. Ut a sapien. Nam nec leo quis mi malesuada viverra. Donec eu velit tincidunt leo facilisis sagittis. Suspendisse vitae nibh a eros viverra fermentum. Nullam at purus. Vestibulum viverra. Praesent a erat. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Sed scelerisque, lectus nonummy feugiat semper, dolor pede nonummy lacus, a hendrerit erat sapien et odio. Nam nec odio ac urna tempus vehicula. Fusce mauris magna, sodales eget, condimentum quis, ultricies non, leo. Mauris tempor, sapien eu blandit varius, massa felis feugiat mauris, eget vulputate dolor ante in lacus. 

Etiam semper diam eu eros. Pellentesque semper, augue pellentesque venenatis lacinia, libero lectus dignissim ante, in vulputate nisi urna non ipsum. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos hymenaeos. Duis ut quam quis elit mollis fermentum. Praesent tristique ullamcorper ipsum. Integer fringilla tristique arcu. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Etiam sagittis. Donec pellentesque consectetuer lorem. Suspendisse potenti. Fusce dapibus turpis et neque. Sed felis. Donec nec ipsum sed libero rutrum mattis. 

Nulla turpis mi, egestas id, porttitor sit amet, nonummy ac, neque. Aenean dignissim neque at velit. Nulla condimentum, ipsum vitae cursus vulputate, lacus diam molestie nisl, eu blandit sem massa non mauris. Nullam malesuada vehicula nunc. Aenean leo. Curabitur iaculis, risus at lobortis dictum, leo est semper massa, vitae tincidunt nulla ligula a lacus. Nulla ultrices est in justo aliquam aliquet. Sed id urna vel lorem convallis iaculis. Quisque sagittis augue nec elit. In quis ipsum. Maecenas ut turpis a est ornare auctor. In mauris nisl, egestas at, iaculis vel, dignissim sed, ante. Aenean laoreet nisl vitae magna. Nunc imperdiet risus eget risus. Nulla lacus ligula, gravida in, dignissim sit amet, tincidunt ac, leo. 

Suspendisse potenti. Sed fringilla massa ut nulla. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nunc viverra, lacus in mattis nonummy, pede nibh pharetra mi, nec viverra arcu sapien in nisl. Proin tincidunt dapibus orci. Vestibulum sem. Vestibulum fringilla dapibus pede. Duis dapibus dignissim justo. Quisque lacus justo, consequat sed, ultrices fermentum, ultrices eu, dolor. Fusce dictum sem in elit. Aliquam sed sem. Suspendisse potenti. Nam quis risus sed velit consectetuer iaculis. Cras quis odio. Duis non orci eget lorem tempor nonummy. Nam in enim non turpis hendrerit ultrices. Curabitur odio. Nullam arcu ligula, facilisis id, congue ac, dapibus quis, pede. Sed dictum sem ac orci. 

Sed ullamcorper, ante ac aliquam ullamcorper, ipsum purus pharetra nisl, auctor varius metus dolor imperdiet tellus. Suspendisse viverra tortor a nulla. Ut ut orci sed nunc tincidunt tristique. Vivamus quis augue nec libero venenatis condimentum. Etiam odio. Ut pulvinar tempus dui. Maecenas tincidunt aliquam dui. Morbi pharetra urna sed odio. Nulla cursus. Mauris dictum commodo eros. 

Sed a purus. Proin risus quam, facilisis eget, iaculis semper, laoreet id, mauris. Morbi id justo quis erat ultricies malesuada. Nullam non erat interdum velit eleifend bibendum. Cras blandit. Sed suscipit volutpat metus. Donec tristique, odio ornare commodo tempor, augue orci tristique sapien, eget euismod urna nibh ut nunc. Aliquam pede libero, hendrerit sed, eleifend nec, rhoncus et, libero. Cras sit amet felis eu pede laoreet imperdiet. Maecenas bibendum fringilla neque. Nullam eget magna vel purus luctus pellentesque. Sed et risus eget pede ornare volutpat. 

Vivamus fermentum orci dapibus pede. Donec sit amet nisl. Maecenas varius condimentum mauris. Curabitur lacinia. Nullam sit amet odio. Integer tempor luctus orci. Etiam egestas, turpis a cursus nonummy, diam sem iaculis ligula, nec egestas lectus sem in neque. Pellentesque tortor nibh, lobortis eget, tristique quis, laoreet eget, libero. Curabitur vestibulum, tortor venenatis iaculis varius, ante tortor hendrerit massa, ac mattis sapien quam eu leo. Donec dictum. Donec porta orci at enim. Curabitur consequat cursus sem. Nulla rutrum tellus sed purus. 

In non metus id nunc lobortis volutpat. Praesent augue nibh, fringilla nec, euismod nec, tempor a, velit. Sed porttitor. In laoreet magna at pede. Quisque lacinia. Curabitur lacus. Sed scelerisque purus non dolor. Vestibulum a augue. Nulla pede velit, malesuada vel, sagittis nec, adipiscing eu, nisi. Nulla non pede. Nam cursus faucibus odio. In euismod, eros vitae laoreet lacinia, lorem leo congue orci, eget laoreet tortor est vestibulum arcu. Praesent pretium venenatis nunc. Nam in ipsum. Proin cursus lacus eget felis. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos hymenaeos. Fusce placerat mollis mauris. 

Aliquam erat volutpat. Curabitur nulla nulla, fermentum accumsan, rhoncus tincidunt, venenatis et, ante. Donec odio. In hac habitasse platea dictumst. Ut gravida bibendum tortor. Suspendisse mauris. Fusce mi nunc, ultrices sed, consectetuer ut, sodales nonummy, enim. In orci lorem, ultricies sit amet, porta eu, blandit at, orci. Fusce non augue. Suspendisse potenti. Duis ornare urna at velit. Nam vitae urna at purus luctus commodo. Sed a lorem a augue scelerisque egestas. Aenean rutrum. Aliquam ut lorem eu sem tristique condimentum. Sed enim. Maecenas ut lacus malesuada elit sodales bibendum. Cras ut metus. Donec sed orci in turpis mattis placerat. Donec lorem. 

Etiam fringilla cursus neque. Etiam libero. Phasellus ornare, sem nec pretium pharetra, metus velit ultrices elit, nec posuere nisi diam ac enim. Proin laoreet viverra leo. Etiam fermentum metus. Morbi sollicitudin lectus eget massa. Nunc libero. Suspendisse interdum faucibus turpis. Maecenas quis purus. Integer luctus. Ut varius. Curabitur nibh. In risus turpis, rhoncus in, suscipit eu, fermentum vitae, orci. Vestibulum scelerisque ornare tellus. 

Vivamus in felis eu enim viverra rutrum. Morbi pretium. Duis turpis. Phasellus id nunc a diam dictum pharetra. Mauris laoreet. Quisque nibh. Morbi sapien. Nunc et lectus. Duis viverra. Aliquam convallis. 

Nam sapien turpis, lacinia ut, lacinia eu, varius id, metus. Suspendisse est turpis, rutrum eu, nonummy tempor, suscipit eget, ipsum. Maecenas euismod, dui id volutpat porttitor, ipsum nibh rutrum nunc, ac ornare mi erat et pede. Curabitur euismod hendrerit magna. Proin molestie nibh pretium augue. Phasellus quam nibh, rutrum non, adipiscing at, auctor sit amet, est. Nunc sit amet ipsum. Suspendisse fringilla metus id lorem sollicitudin dictum. Suspendisse neque orci, imperdiet quis, lacinia at, feugiat volutpat, mauris. Praesent vel turpis vitae dolor ultricies facilisis. Phasellus vitae tortor. Praesent ipsum massa, elementum et, eleifend at, accumsan a, orci. Duis sit amet tellus. Pellentesque et orci sit amet velit mattis rhoncus. Pellentesque sodales metus non arcu. 

Nam fermentum, odio in hendrerit dignissim, odio mauris lacinia lorem, vel volutpat ipsum quam eu augue. In et purus et tortor volutpat dictum. Phasellus sit amet sapien. Aenean pretium lorem non eros. Fusce volutpat ligula et quam. Aliquam nonummy, tellus sit amet viverra venenatis, purus dui pharetra dolor, vitae mattis lacus leo ut ipsum. Mauris mi tortor, blandit sed, venenatis ac, convallis a, eros. Donec tincidunt venenatis tellus. Aliquam tristique fringilla augue. Maecenas convallis malesuada lorem. Aliquam pellentesque tortor eu nibh. 

Curabitur odio. Aliquam tincidunt felis at sem. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Integer euismod aliquet metus. Sed vehicula dictum eros. Morbi quis lacus. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Morbi id nisi ut sapien blandit fringilla. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nullam ligula diam, faucibus vitae, suscipit eget, ullamcorper sed, neque. Cras nisl tortor, pulvinar eget, cursus sed, imperdiet at, mi. Ut rutrum sapien tincidunt erat. Integer placerat condimentum urna. Sed a orci. Donec libero magna, nonummy tempor, porttitor eget, pretium eu metus. 

        
      </div>
   </form>
</body>

</html>
