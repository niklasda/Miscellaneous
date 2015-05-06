using System.Collections.Generic;
using System.Web.UI.WebControls;
using nida.model;
using Spring.Context;
using Spring.Context.Support;

namespace nida.presenter
{
    public class UserListPresenter
    {
        private DataList _view;
        private List<MyParent> _model;
        private IUserHandler _userHandler;

        public UserListPresenter(Anthem.DataList view)
        {
            _view = view;

            IApplicationContext ctx = ContextRegistry.GetContext();
            _userHandler = (IUserHandler)ctx.GetObject("MyUserHandler");
        }

        public void ShowUsers()
        {
            _model = _userHandler.RetrieveParents();

            _view.DataSource = _model;
            _view.DataBind();
        }
    }
}